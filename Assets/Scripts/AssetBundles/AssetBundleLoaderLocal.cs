﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBundleLoaderLocal : MonoBehaviour
{
    AssetBundle assetBundle;
    string assetBundlePath = "D:/github/UnityCertPrep/Assets/StreamingAssets/bear";

    // Start is called before the first frame update
    void Start()
    {
        LoadAssets();
    }

    void LoadAssets()
    {
        assetBundle = AssetBundle.LoadFromFile(assetBundlePath);
        if (assetBundle == null)
        {
            Debug.Log("bundle was unable to load: asset bundle is null");
            return;
        }
        Debug.Log("Bundle Loaded");

        //instantiate prefab included inside the assetbundle
        GameObject assetPrefab = assetBundle.LoadAsset<GameObject>("ZomBear.fbx");
        Instantiate(assetPrefab);

        //load texture in bundle
        Texture tex = assetBundle.LoadAsset<Texture>("ZomBearDiffuse.png");
        Renderer rend = assetPrefab.GetComponentInChildren<SkinnedMeshRenderer>();
        rend.sharedMaterials[0].mainTexture = tex;
    }
}