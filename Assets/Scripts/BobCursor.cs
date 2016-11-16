using UnityEngine;

public class BobCursor : MonoBehaviour
{
    private int floatDistance = 1;

    private MeshRenderer meshRenderer;
    private BobDetector bobDetector;

    public Material[] bob_materials;

    private int lastDetectedBob = 0;

    void Start()
    {
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
        bobDetector = this.gameObject.GetComponentInChildren<BobDetector>();
    }

    void Update()
    {
        var newDetectedBob = bobDetector.ReadDetectedBob().GetHashCode();
        if (newDetectedBob != lastDetectedBob)
        {
            this.meshRenderer.material = bob_materials[newDetectedBob];
            lastDetectedBob = newDetectedBob;
        }
    }
}