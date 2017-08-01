using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMusic : MonoBehaviour
{
    public AudioSource music2;
    public HeroAttack hatk;
    public HeroSkill hsk;
    public HeroStatus hs;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //普攻音效
        if (!hatk.ifattack)
        {
            Debug.Log("AS");
            music2.clip = Resources.Load("cross") as AudioClip;
            int a = 0;
            if (!music2.isPlaying&&a==0)
            {
                //播放音乐
                music2.Play();
                a += 1;
            }

        }
        //技能1音效
        if (ETCInput.GetButton("SkillTwo")&&hsk.music2)
        {
            Debug.Log("AS");
            music2.clip = Resources.Load("spike2") as AudioClip;
            //int a = 0;
            if (!music2.isPlaying)
            {
                //播放音乐
                music2.Play();
                hsk.music2 = false;
            }

        }
        //大招音效
        if (ETCInput.GetButton("SkillThree")&&hsk.music3)
        {
            Debug.Log("AS");
            music2.clip = Resources.Load("huh") as AudioClip;
            //int a = 0;
            if (!music2.isPlaying)
            {
                //播放音乐
                music2.Play();
                hsk.music3 = false;
            }

        }
        //位移音效
        if (ETCInput.GetButton("SkillOne")&&hsk.music1)
        {
            Debug.Log("AS");
            music2.clip = Resources.Load("hit_m_runout") as AudioClip;
            if (!music2.isPlaying)
            {
                //播放音乐
               music2.Play();
                hsk.music1= false;
            }

        }
        //受伤音效
        if (hs.Patk)
        {
            Debug.Log("AS");
            music2.clip = Resources.Load("heartbeat") as AudioClip;
            if (!music2.isPlaying)
            {
                //播放音乐
                music2.Play();
            }

        }
        //升级音效
       /* if (!hatk.ifattack)
        {
            Debug.Log("AS");
            music2.clip = Resources.Load("cross") as AudioClip;
            if (!music2.isPlaying)
            {
                //播放音乐
                music2.Play();
            }

        }*/
    }
}
