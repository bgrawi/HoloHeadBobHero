using UnityEngine;
using System.Collections;

public class DebugSelectAfter2seconds : MonoBehaviour {

    int time = 0;
    bool fired = false;
	// Update is called once per frame
	void Update () {
        if(fired)
        {
            return;
        }
	    time += (int)System.Math.Floor(Time.deltaTime * 1000);

        if(time > 2000)
        {
            this.SendMessageUpwards("OnSelect");
            fired = true;
        }
    }
}
