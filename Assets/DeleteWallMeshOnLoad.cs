using UnityEngine;
using System.Collections;
using HoloToolkit.Unity;

public class DeleteWallMeshOnLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var collider = GetComponent<Collider>();
        var bounds = collider.bounds;

        Debug.Log("DELETING PLANES FOR WALL");
        return;
        foreach (var plane in SurfaceMeshesToPlanes.Instance.ActivePlanes)
        {
            if(plane == null || !plane.activeSelf)
            {
                continue;
            }
            if (bounds.Intersects(plane.GetComponent<Collider>().bounds))
            {
                Destroy(plane);
            }
        }
    }
}
