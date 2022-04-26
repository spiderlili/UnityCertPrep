using UnityEngine;

// TODO: Make editor window to save mesh: run CombineAllMeshes & save to disk
// TODO: Make material
public class MeshCombiner : MonoBehaviour
{
    [SerializeField]private GameObject meshGroup;
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
    }
}
