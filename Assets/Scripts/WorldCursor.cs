using HoloToolkit.Unity;
using UnityEngine;

public class WorldCursor : MonoBehaviour
{

    public bool OnlyWalls = false;

    public bool ForceVertical = true;

    private int raycastMask;
    private MeshRenderer meshRenderer;

    // Use this for initialization
    void Start()
    {

        raycastMask = OnlyWalls ? SpatialMappingManager.Instance.WallMask : int.MinValue;
        // Grab the mesh renderer that's on the same object as this script.
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;

        if (Physics.Raycast(new Ray(headPosition, gazeDirection), out hitInfo, 100f, raycastMask))
        {
            // If the raycast hit a hologram...
            // Display the cursor mesh.
            meshRenderer.enabled = true;

            // Move the cursor to the point where the raycast hit.
            this.transform.position = hitInfo.point + (0.02f * hitInfo.normal);

            // Rotate the cursor to hug the surface of the hologram.
            var destRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            Vector3 v = destRotation.eulerAngles;
            var x = v.x;
            if(ForceVertical)
            {
                x = 90;
            }
            this.transform.rotation = Quaternion.Euler(x, v.y, v.z);
        }
        else
        {
            
            // If the raycast did not hit a hologram, hide the cursor mesh.
            meshRenderer.enabled = false;
        }
    }
}