using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public InputField inputName;

    void Awake()
    {
        HighestScoreText();
    }

    public void HighestScoreText()
    {
        if (GameData.session.username != null)
        {
            highScoreText.text = "Best Score:" + GameData.session.username + ":" + GameData.session.m_Points;
            Debug.Log(GameData.session.username + " " + GameData.session.m_Points);
        }
    }

    public void TopButton()
    {
        SceneManager.LoadScene("Top");
    }
    public void StartGameButton()
    {
        Game.current.SetName(inputName);
        SceneManager.LoadScene("main");
    }
    public void QuitButton()
    {
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
