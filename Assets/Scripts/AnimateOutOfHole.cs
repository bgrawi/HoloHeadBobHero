using UnityEngine;
using System.Collections;

public class AnimateOutOfHole : MonoBehaviour {

    Transform target;
    BobDetector detector;

    bool isDetectingBob = false;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("BobTarget").transform;
        detector = GameObject.Find("BobCursor").GetComponent<BobDetector>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Rigidbody>().isKinematic)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 3f * Time.deltaTime);
        }
        if(isDetectingBob)
        {
            if (detector.CheckDetectedBob(BobDetector.DetectedBob.DOWN))
            {
                Debug.Log("GOT BOB");
                ((Behaviour)GetComponent("Halo")).enabled = false;
                Destroy(gameObject);
            }
        }
	}

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "BobDetectReady")
        {
            ((Behaviour) GetComponent("Halo")).enabled = true;
            isDetectingBob = true;
        }
        else if (collider.gameObject.name == "BobMissed")
        {
            isDetectingBob = false;
            ((Behaviour) GetComponent("Halo")).enabled = false;
            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
        }
    }
}
