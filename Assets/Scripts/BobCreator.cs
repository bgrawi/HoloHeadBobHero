using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.VR.WSA;

public class BobCreator : MonoBehaviour {

    public GameObject Bob;

    public GameObject SpawnLocation;

    public GameObject Speakers;

    public List<GameObject> activeBobs = new List<GameObject>();

    public Song currentSong;

    private int totalTime = 0;
    private bool startedAudio = false;
    private bool stoppedSpatialMapper = false;

    private int timeCount = 0;

    private Vector3 speakerOriginalPos;

    private Vector3 speakerTriggerPos;

    // Use this for initialization
    void Start () {
        speakerOriginalPos = Speakers.transform.position;
        speakerTriggerPos = Speakers.transform.position - new Vector3(0, 0, .1f);
    }

    private bool detectBob()
    {
        return Camera.main.transform.eulerAngles.x > 10 && Camera.main.transform.eulerAngles.x < 180;
    }
	
	// Update is called once per frame
	void Update () {
        int deltaTime = (int) System.Math.Floor(Time.deltaTime * 1000);
        totalTime += deltaTime;
        timeCount += deltaTime;

        if(!startedAudio && totalTime > 3000)
        {
            currentSong.PlaySong();
            startedAudio = true;
        }

        if(!stoppedSpatialMapper && totalTime > 10000)
        {
            //GameObject.FindGameObjectWithTag("SpatialMapper").GetComponent<SpatialMappingCollider>().freezeUpdates = true;
            stoppedSpatialMapper = true;
        }

        if (timeCount > 50)
        {
            if (currentSong.PopBob() == 1)
            {
                var newBob = Instantiate(Bob, SpawnLocation.transform.position, Quaternion.Euler(0, 0, 180)) as GameObject;
                newBob.SetActive(true);
                activeBobs.Add(newBob);
            }
            timeCount -= 50;
        }

        if(detectBob())
        {
            Speakers.transform.position = speakerTriggerPos;
        } else
        {
            Speakers.transform.position = speakerOriginalPos;
        }

        var en = activeBobs.GetEnumerator();
        var removeBobs = new List<GameObject>();
        while (en.MoveNext())
        {
            if (en.Current.transform.position.z < 3.8)
            {
                ((Behaviour) en.Current.GetComponent("Halo")).enabled = true;
                if (detectBob())
                {
                    Destroy(en.Current);
                    removeBobs.Add(en.Current);
                }
            }
            if (en.Current.transform.position.z < 3.3)
            {
                ((Behaviour)en.Current.GetComponent("Halo")).enabled = false;
                var rigidbody = en.Current.GetComponent<Rigidbody>();
                rigidbody.isKinematic = false;
                //rigidbody.AddForce(new Vector3(0, 0, -30f * Time.deltaTime));
                removeBobs.Add(en.Current);
            }
        }
        activeBobs.RemoveAll((match) => removeBobs.Contains(match));

	}
}
