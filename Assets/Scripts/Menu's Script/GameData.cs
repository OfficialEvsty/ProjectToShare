using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    [SerializeField] public string username;
    public int m_Points;
    public static GameData session = new GameData();
    public void Reset(int score)
    {
        if(m_Points < score)
        {
            session.username = Game.current.GetName();
            session.m_Points = Game.current.GetScore();
        }
    }

}
