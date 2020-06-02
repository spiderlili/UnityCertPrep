using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//Fastest way to load assetbundle: runs as a coroutine to allow a project to continue to run while asset bundle is loaded
public class LoadAssetBundleFromFileAsync : MonoBehaviour
{
    public string bundleName;
    public string assetName;

    IEnumerator Start()
    {
        AssetBundleCreateRequest asyncBundleRequest = AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, bundleName));
        yield return asyncBundleRequest;

        AssetBundle localAssetBundle = asyncBundleRequest.assetBundle;

        if(localAssetBundle == null)
        {
            Debug.LogError("Failed to load AssetBundle");
            yield break;
        }

        AssetBundleRequest assetRequest = localAssetBundle.LoadAssetAsync<GameObject>(assetName);
        yield return assetRequest;

        GameObject prefab = assetRequest.asset as GameObject;
        Instantiate(prefab);

        localAssetBundle.Unload(false);
    }
}
