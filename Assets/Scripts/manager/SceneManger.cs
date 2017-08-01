using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour
{
    public Create cre;
    public GameObject Music;
    public string level;
    //private string btnName;
    private int selectRole=0;
    private int selectBattle = 0;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(Music);
        Button[] buttons = GetComponentsInChildren<Button>(true);
        foreach (var item in buttons)
        {
            Button btn = item;
            btn.onClick.AddListener(delegate () {
                this.OnClick(btn.gameObject);
            });
        }
    }
    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnClick(GameObject sender)
    {
        switch (sender.name)
        {
            case "Button1":
                selectRole = 1;
                Debug.Log(selectRole);
                break;
            case "Button2":
                selectRole = 2;
                Debug.Log(selectRole);
                break;
            case "Button3":
                selectRole = 3;
                Debug.Log(selectRole);
                break;
            case "Button4":
                selectRole = 4;
                Debug.Log(selectRole);
                break;
            case "nButton":

                if (selectRole == 0)       
                    break;
                else
                {
                    PlayerPrefs.SetInt("Role", selectRole);
                    SceneManager.LoadScene("name");
                }
                break;

            case "level1.1":
                selectBattle = 1;
                break;
            case "level1.2":
                selectBattle = 2;
                break;
            case "level1.3":
                selectBattle = 3;
                break;
            case "BattleConfirm":
                if (selectBattle ==0)
                    break;
                if (selectBattle == 3)
                {
                    PlayerPrefs.SetInt("MusicScene", 2);
                    PlayerPrefs.SetInt("Battle", selectBattle);
                    SceneManager.LoadScene("fight");
                }
                else
                { 
                    PlayerPrefs.SetInt("MusicScene", 1);
                PlayerPrefs.SetInt("Battle", selectBattle);
                    SceneManager.LoadScene("fight");
                }
                break;
            case "BattleBack":
                PlayerPrefs.SetInt("Battle", 0);
                break;
            default:
                Debug.Log("none");
                break;
        }
    }
    public void SelectScene(string scene)
    {
        level = scene;
        SceneManager.LoadScene(level);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        SceneManager.LoadScene(level);
    }




}
