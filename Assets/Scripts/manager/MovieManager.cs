using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovieManager : MonoBehaviour {
    public MovieTexture movTexture;
    void Start()
    {
        //设置电影纹理播放模式为循环
        movTexture.loop = false;
    }

  void update()
    {
        if (movTexture.isPlaying)
        {
            Debug.Log("111");
            //SceneManager.LoadScene("select");
        }
    }
    void OnGUI()
    {
        //绘制电影纹理
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movTexture, ScaleMode.StretchToFill);
        movTexture.Play();
       
    }
}
