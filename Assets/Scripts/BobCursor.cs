using UnityEngine;

public class BobCursor : MonoBehaviour
{
    private int floatDistance = 1;

    private MeshRenderer meshRenderer;
    private BobDetector bobDetector;

    public Material[] bob_materials;

    // Use this for initialization
    void Start()
    {
        // Grab the mesh renderer that's on the same object as this script.
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
        bobDetector = this.gameObject.GetComponentInChildren<BobDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        this.meshRenderer.material = bob_materials[bobDetector.ReadDetectedBob().GetHashCode()];

        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        var cursorRotation = Camera.main.transform.rotation;

        cursorRotation *= Quaternion.Euler(270, 0, 0);
        this.transform.rotation = cursorRotation;
        this.transform.position = headPosition + (gazeDirection.normalized * floatDistance);
    }
}