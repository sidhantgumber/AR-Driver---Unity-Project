using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ToggleMesh : MonoBehaviour
{

    public ARMeshManager meshManager;
    public Material invisibleMaterial;
    public Material visibleMaterial;
    bool isVisible = true;

    public void ToggleMeshVisualization()
    {
        var meshes = meshManager.meshes;
        var meshPrefabRenderer = meshManager.meshPrefab.GetComponent<MeshRenderer>();
        if (isVisible)
        {
            meshPrefabRenderer.material = invisibleMaterial;
            foreach (var mesh in meshes)
            {
                mesh.GetComponent<MeshRenderer>().material = invisibleMaterial;
            }
            isVisible = false;
        }
        else
        {
            meshPrefabRenderer.material = visibleMaterial;
            foreach (var mesh in meshes)
            {
                mesh.GetComponent<MeshRenderer>().material = visibleMaterial;
            }
            isVisible = true;
        }
    }
}
