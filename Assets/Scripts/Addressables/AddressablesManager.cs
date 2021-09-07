using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressablesManager : MonoBehaviour
{
    [SerializeField] private Image image;
    // private GameObject prefab; // Old workflow
    [SerializeField] private AssetReferenceGameObject assetReferenceGameObject;
    [SerializeField] private AssetReference assetReferenceGameScene; // No specific type for a scene - general AssetReference
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
        Debug.Log("Load Addressable Sprite");
    }
}
