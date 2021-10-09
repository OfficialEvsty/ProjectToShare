using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI topPlayers;
    // Start is called before the first frame update

    public void ReturnButton()
    {
        SceneManager.LoadScene("menu");
    }

    public void GetTopPlayers()
    {
        var saves = SavingSystem.savedGames;
        saves.Sort((x, y) => -x.m_Points.CompareTo(y.m_Points));
        topPlayers.text = "Top players \n\n";
        foreach(GameData player in saves)
        {
            topPlayers.text += player.username + " : " + player.m_Points + "\n";
        }
    }
    void Awake()
    {
        SavingSystem.Load();
        GetTopPlayers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
