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
        var result = detectedBob == checkBob;

        if(result)
        {
            detectionState = DetectionState.COMPLETED;
            detectedBob = DetectedBob.NONE;
        }

        return result;
    }

    void Update () {
        DetectedBob currentBob;
        if (Camera.main.transform.eulerAngles.x > 10 && Camera.main.transform.eulerAngles.x < 180)
        {
            currentBob = DetectedBob.DOWN;
        } else if (Camera.main.transform.eulerAngles.z > 10 && Camera.main.transform.eulerAngles.z < 90)
        {
            currentBob = DetectedBob.LEFT;
        }
        else if (Camera.main.transform.eulerAngles.z > 270 && Camera.main.transform.eulerAngles.z < 350)
        {
            currentBob = DetectedBob.RIGHT;
        }
        else
        {
            currentBob = DetectedBob.NONE;
        }

        if(detectionState == DetectionState.OPEN)
        {
            detectedBob = currentBob;
        } else if (detectionState == DetectionState.COMPLETED && currentBob == DetectedBob.NONE)
        {
            detectionState = DetectionState.OPEN;
            detectedBob = currentBob;
        }
	}
}
