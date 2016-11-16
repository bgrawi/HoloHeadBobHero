using UnityEngine;
using System.Collections;

public class FloatInFront : MonoBehaviour {

    [Tooltip("Distance to float in front of camera")]
    public float FloatDistance = 1.0f;

    // Update is called once per frame
    void Update () {
        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        var cursorRotation = Camera.main.transform.rotation;

        cursorRotation *= Quaternion.Euler(270, 0, 0);
        this.transform.rotation = cursorRotation;
        this.transform.position = headPosition + (gazeDirection.normalized * FloatDistance);
    }
}
