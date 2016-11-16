using UnityEngine;
using System.Collections;

public class AnimateOutOfHole : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Rigidbody>().isKinematic)
        {
            transform.Translate(new Vector3(0, 0, -3f * Time.deltaTime));
        }
	}
}
