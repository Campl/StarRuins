using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    public AudioSource music;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(PlayerPrefs.GetInt("MusicScene")==0)
        {
            music.clip = Resources.Load("DC41") as AudioClip;
            if (!music.isPlaying)
            {
                //播放音乐
                music.Play();
            }
        }
        if (PlayerPrefs.GetInt("MusicScene") == 2)
        {
            music.clip = Resources.Load("Desertsound") as AudioClip;
            if (!music.isPlaying)
            {
                //播放音乐
                music.Play();
            }
        }
        if (PlayerPrefs.GetInt("MusicScene") == 1)
        {
            music.clip = Resources.Load("barloop1") as AudioClip;
            if (!music.isPlaying)
            {
                //播放音乐
                music.Play();
            }
        }
    }
}
