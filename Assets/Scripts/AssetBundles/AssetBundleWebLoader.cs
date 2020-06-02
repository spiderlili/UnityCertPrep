using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.VersionControl;
using UnityEngine.Networking;

public class AssetBundleWebLoader : MonoBehaviour
{
    public string bundleUrl = "http://localhost/assetbundles/testbundle";
    public string assetName = "BundledObject";

    // Start is called before the first frame update
    IEnumerator Start()
    {
        using (UnityWebRequest web = new UnityWebRequest(bundleUrl))
        {
            yield return web;
            UnityWebRequest remoteAssetBundle = UnityWebRequestAssetBundle.GetAssetBundle(bundleUrl);
            if(remoteAssetBundle == null)
            {
                Debug.LogError("Failed to download AssetBundle");
                yield break;
            }
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(remoteAssetBundle);
            Instantiate(bundle.LoadAsset(assetName));
            bundle.Unload(false);
        }
    }
}
