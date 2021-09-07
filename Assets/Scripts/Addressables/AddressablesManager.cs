using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

// TODO: configure sprite swapping, use the Addressables Event Viewer to see the memory beig managed for you, try other asset types (audioclips, materials, videoclips, etc)
public class AddressablesManager : MonoBehaviour
{
    [SerializeField] private Image imageForAddressableSprite;
    // private GameObject prefab; // Old workflow
    [SerializeField] private AssetReferenceGameObject assetReferenceGameObject;
    [SerializeField] private AssetReference assetReferenceGameScene; // No specific type for a scene - general AssetReference
    [SerializeField] private AssetReferenceSprite assetReferenceSprite;
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
    public void AddressableSprite()
    {
        // When the LoadAssetAsync() completes: the Completed delegate is called
        assetReferenceSprite.LoadAssetAsync().Completed += OnSpriteLoaded;
        Debug.Log("Load Addressable Sprite");
    }

    // OnSpriteLoaded() has been passed to the Completed delegate as a callback
    private void OnSpriteLoaded(AsyncOperationHandle<Sprite> handle)
    {
        imageForAddressableSprite.sprite = handle.Result;
    }
}
