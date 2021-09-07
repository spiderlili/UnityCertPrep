using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.U2D; // For working with sprite atlases

// TODO: configure sprite swapping, use the Addressables Event Viewer to see the memory beig managed for you, try other asset types (audioclips, materials, videoclips, etc)
public class AddressablesManager : MonoBehaviour
{
    [SerializeField] private Image imageForAddressableSprite;
    // private GameObject prefab; // Old workflow
    [SerializeField] private AssetReferenceGameObject assetReferenceGameObject;
    [SerializeField] private AssetReference assetReferenceGameScene; // No specific type for a scene - general AssetReference
    [SerializeField] private AssetReferenceSprite assetReferenceSprite;
    
    [Tooltip("If game’s data is stored in a JSON or text file for projects that allow for user-edited content, or is subject to change at runtime: specify address for Sprite directly")]
    [SerializeField] private string assetReferenceSpriteAddress;
    [Tooltip("Enable useAddress to load octagon sprite, otherwise load triangle sprite by reference")]
    [SerializeField] private bool useAddress;
    
    [Header("Load Addressable Atlased Sprites")]
    [SerializeField] private AssetReferenceAtlasedSprite newAtlasedSprite;
    [SerializeField] private string spriteAtlasAddress;
    [SerializeField] private string atlasedSpriteName;
    [Tooltip("Enable useAtlasedSpriteName to load circle sprite from sprite atlas")]
    [SerializeField] private bool useAtlasedSpriteName;

    [Header("Load Parent & Child Object Hierarchy")]
    [Tooltip("Parent Object")]
    [SerializeField] private AssetReference mainObjectToLoad;
    [Tooltip("Child Object")]
    [SerializeField] private AssetReference accessoryObjectToLoad;
    private GameObject instantiatedObject;
    private GameObject instantiatedAccessoryObject;

    private void Start()
    {
        Addressables.LoadAssetAsync<GameObject>(mainObjectToLoad).Completed += ObjectLoadDone;
    }
    
    // Instantiate the object after it's loaded & instantiate the accessory child object
    private void ObjectLoadDone(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded) {
            GameObject loadedObject = obj.Result;
            Debug.Log("Successfully loaded object!");
            instantiatedObject = Instantiate(loadedObject);
            Debug.Log("Successfully instantiated object!");

            if (accessoryObjectToLoad != null) {
                // InstantiateAsync loads & instantiates an Addressable Asset in a single step. LoadAssetAsync loads an Addressable Asset into memory, but does not instantiate it. 
                accessoryObjectToLoad.InstantiateAsync(instantiatedObject.transform).Completed += op => {
                    if (op.Status == AsyncOperationStatus.Succeeded) {
                        instantiatedAccessoryObject = op.Result;
                        Debug.Log("Successfully loaded & instantiated accessory child object!");
                    }
                };
            }
        }
    }
    public void AddressablePrefab()
    {
        Addressables.InstantiateAsync(assetReferenceGameObject);
        Debug.Log("Load Addressable Prefab");
        // GameObject.Instantiate(prefab); // Old workflow
    }
    
    public void AddressableScene()
    {
        assetReferenceGameScene.LoadSceneAsync(UnityEngine.SceneManagement.LoadSceneMode.Additive);
        Debug.Log("Load Addressable Scene");
    }
    
    // Callback: a method is called to load the asset - this happens on a separate thread
    // registers a listener for the Completed callback of the load command, which is invoked immediately
    public void AddressableSprite()
    {
        // Load Atlased Sprite
        if (useAtlasedSpriteName) {
            string atlasedSpriteAddress = spriteAtlasAddress + '[' + atlasedSpriteName + ']';
            // Addressables.LoadAssetAsync<Sprite>(atlasedSpriteAddress).Completed += OnSpriteLoaded;
            
            // Load the Atlas and use a helper function to find the Sprite by its name.
            Addressables.LoadAssetAsync<SpriteAtlas>(spriteAtlasAddress).Completed += OnSpriteAtlasLoaded;
        } else {
            // Load unatlased Sprite
            if (useAddress) {
                // When the LoadAssetAsync() completes: the Completed delegate is called. LoadAssetAsync loads an Addressable Asset into memory, but does not instantiate it. 
                Addressables.LoadAssetAsync<Sprite>(assetReferenceSpriteAddress).Completed += OnSpriteLoaded;
            } else {
                assetReferenceSprite.LoadAssetAsync().Completed += OnSpriteLoaded;
            }
            Debug.Log("Load Addressable Sprite");
        }
    }

    // OnSpriteLoaded() has been passed to the Completed delegate as a callback
    // code to be executed once Sprite is loaded can either be a delegate or, for simpler cases, a lambda expression.
    private void OnSpriteLoaded(AsyncOperationHandle<Sprite> handle)
    {
        switch (handle.Status) {
            case AsyncOperationStatus.Succeeded:
                imageForAddressableSprite.sprite = handle.Result;
                break;
            case AsyncOperationStatus.Failed:
                Debug.LogError("Sprite Load Failed!");
                break;
            default:
                break;
        }
    }
    
    private void OnSpriteAtlasLoaded(AsyncOperationHandle<SpriteAtlas> handle)
    {
        switch (handle.Status) {
            case AsyncOperationStatus.Succeeded:
                imageForAddressableSprite.sprite = handle.Result.GetSprite(atlasedSpriteName);
                break;
            case AsyncOperationStatus.Failed:
                Debug.LogError("Sprite Load from Sprite Atlas Failed!");
                break;
            default:
                break;
        }
    }
}
