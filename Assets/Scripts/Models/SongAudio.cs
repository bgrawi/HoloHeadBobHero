using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class SongAudio : MonoBehaviour
{
    public void StartSong()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        //audio.Play(44100);
    }
}