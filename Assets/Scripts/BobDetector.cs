using UnityEngine;
using System.Collections;

public class BobDetector : MonoBehaviour {

    public enum DetectedBob
    {
        NONE = 0, DOWN = 1, LEFT = 2, RIGHT = 3
    }

    public enum DetectionState
    {
        OPEN, COMPLETED, MISSED
    }

    private DetectionState detectionState = DetectionState.OPEN;
    private DetectedBob detectedBob = DetectedBob.NONE;

    public DetectedBob ReadDetectedBob()
    {
        return detectedBob;
    }

    public bool CheckDetectedBob(DetectedBob checkBob)
    {
        return detectedBob == checkBob;
    }

    void Update () {

        if (Camera.main.transform.eulerAngles.x > 10 && Camera.main.transform.eulerAngles.x < 180)
        {
            detectedBob = DetectedBob.DOWN;
        } else if (Camera.main.transform.eulerAngles.z > 10 && Camera.main.transform.eulerAngles.z < 90)
        {
            detectedBob = DetectedBob.LEFT;
        }
        else if (Camera.main.transform.eulerAngles.z > 270 && Camera.main.transform.eulerAngles.z < 350)
        {
            detectedBob = DetectedBob.RIGHT;
        }
        else
        {
            detectedBob = DetectedBob.NONE;
        }
	}
}
