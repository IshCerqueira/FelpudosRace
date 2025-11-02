using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update

    public void OnclickMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnClickMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
