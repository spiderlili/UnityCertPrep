using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

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
    
    public void AddressableSprite()
    {
        assetReferenceSprite.LoadAssetAsync().Completed += OnSpriteLoaded;
        Debug.Log("Load Addressable Sprite");
    }

    private void OnSpriteLoaded(AsyncOperationHandle<Sprite> handle)
    {
        imageForAddressableSprite.sprite = handle.Result;
    }
}
