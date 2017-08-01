using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour {

    private void Start()
    {
        PlayerPrefs.SetInt("MusicScene",0);
    }
    //退出
    public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}
