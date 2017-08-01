using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {


    public InputField inputField;
    public Text inputText;
    private string text;

    // Use this for initialization
    void Start () {
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
	void Update () {
        text = inputText.text;

    }

    public void OnClick(GameObject sender)
    {


        switch (sender.name)
        {
           
            case "nButton":
                Debug.Log(text);
                if (text == "")
                {
                    break;
                }
                else
                {
                    PlayerPrefs.SetString("Name", text);
                    SceneManager.LoadScene("scene4");
                }
                break;
            case "bButton":
              SceneManager.LoadScene("select");
                break;
            default:
                Debug.Log("none");
                break;
        }


    }
}
