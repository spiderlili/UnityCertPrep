﻿using UnityEngine;


// To save the generated mesh: Right click on Mesh Filter > Save Mesh

public class MeshCombiner : MonoBehaviour
{
    [SerializeField] private GameObject meshGroup;
    [SerializeField] private Material meshCombinedMaterial;

    private void Start()
    {
        CombineAllMeshes();
    }
    
    public void CombineAllMeshes()
    {
        if (meshGroup != null) {
            MeshFilter[] filters = meshGroup.GetComponentsInChildren<MeshFilter>();
            CombineInstance[] combineInstances = new CombineInstance[filters.Length];

            for (int i = 0; i < filters.Length; i++) {
                combineInstances[i].mesh = filters[i].sharedMesh;
                combineInstances[i].transform = filters[i].transform.localToWorldMatrix;
            }

            Mesh finalMesh = new Mesh();
            finalMesh.CombineMeshes(combineInstances);

            GetComponent<MeshFilter>().sharedMesh = finalMesh;
        }

        if (meshCombinedMaterial != null) {
            GetComponent<MeshRenderer>().sharedMaterial = meshCombinedMaterial;
        }
    }

    // TODO: Make material and assign to this object's mesh
    void CreateMaterial()
    {
        
    }
}
