using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetBundleCreator : Editor
{
    [MenuItem("Assets/Build Asset Bundles")] //appear under Assets menu
    static void BuilAll() //get run when selected from menu
    {
        //path To Folder: where the asset bundle will go, how it will be built out(chunk based compression), target platform
        //to be compatible with all platforms: need to create an asset bundle for each platform and load them based on platform
        BuildPipeline.BuildAssetBundles("Assets/Scripts/AssetBundles/AssetBundlesTest", BuildAssetBundleOptions.ChunkBasedCompression,
            BuildTarget.StandaloneWindows);
    }
}
