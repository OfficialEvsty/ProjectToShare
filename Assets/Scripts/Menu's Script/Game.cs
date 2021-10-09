using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{
    public static Game current;
    [SerializeField] private string username;
    private int m_Points;


    public string SetName(InputField field)
    {
        username = field.text;
        return username;
    }

    public int SetScore(int score)
    {
        m_Points = score;
        return m_Points;
    }

    public string GetName()
    {
        return username;
    }
    
    public int GetScore()
    {
        return m_Points;
    }

    private void Awake()
    {
        if (current != null)
        {
            Destroy(gameObject);
            return;
        }
        current = this;

        DontDestroyOnLoad(gameObject);
        SavingSystem.Load();
        SavingSystem.TopPlayer();
        Debug.Log(GameData.session.username + " " + GameData.session.m_Points);
}
}
