using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public GameObject PlayerName;

    public void StartGame()
    {
        StorePlayerName();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }
    }

    public void StorePlayerName()
    {
        string PlayerNameText = PlayerName.GetComponent<InputField>().text;

        if (PlayerNameText == "")
        {
            BestScoreManager.Instance.ScoreName = "Anonymous";
        }
        else
        {
            BestScoreManager.Instance.ScoreName = PlayerNameText;
        }
    }
}
