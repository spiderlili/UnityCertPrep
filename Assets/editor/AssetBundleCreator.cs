using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class AssetBundleCreator : Editor
{
    [MenuItem("Assets/Build Asset Bundles")] //appear under Assets menu
    static void BuilAllAssetBundles() //get run when selected from menu
    {
        string assetBundleDirectory = "Assets/StreamingAssets";

        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        //path To Folder: where the asset bundle will go, how it will be built out(chunk based compression), target platform
        //to be compatible with all platforms: need to create an asset bundle for each platform and load them based on platform
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.ChunkBasedCompression,
            BuildTarget.StandaloneWindows); //or: EditorUserBuildSettings.activeBuildTarget for auto target detection
    }
}
