using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Song : MonoBehaviour
{
    // Every bob is 50ms
    public List<int> bobs = new List<int>();
    public string name = "Default";
    public SongAudio songAudio;

    private int bobIndex = 0;

    public void Start()
    {
        // TODO remove this and just parse in bobs
        for (int index = 0; index < 1200; index++)
        {
            if ((index + 12) % 22 == 0)
            {
                bobs.Add(1);
            } else
            {
                bobs.Add(0);
            }
        }
    }

    public int PopBob()
    {
        if(bobIndex >= bobs.Count)
        {
            return 0;
        }
        return bobs[bobIndex++];
    }

    public void PlaySong()
    {
        songAudio.StartSong();
    }
}
