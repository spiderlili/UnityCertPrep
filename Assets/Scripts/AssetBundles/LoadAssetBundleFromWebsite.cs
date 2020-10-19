using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadAssetBundleFromWebsite : MonoBehaviour
{
    private string assetBundleUrl = "https://github.com/spiderlili/UnityCertPrep/blob/master/Assets/BundledAssets/onlineBundle/playerbrutius"; //Failed to decompress data
    private string prefabName = "Brutius.prefab";
    private string fallbackAssetBundleurl = "http://files.holistic3d.com/Bundles/brutius";

    // it must wait for the web call to occur
    IEnumerator Start()
    {
        var unityWebRequestAB = UnityWebRequestAssetBundle.GetAssetBundle(fallbackAssetBundleurl);
        //use yield as it can take sometime for the web request to occur depending on the internet connection - wait for that to happen
        yield return unityWebRequestAB.SendWebRequest();

        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(unityWebRequestAB);
        var loadAsset = bundle.LoadAssetAsync(prefabName);
        //make asset load in sync with start so the program is not stuck during waiting if it's got other things to do
        yield return loadAsset;

        Instantiate(loadAsset.asset);
    }
}