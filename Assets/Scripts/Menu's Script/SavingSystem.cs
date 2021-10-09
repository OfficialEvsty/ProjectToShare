using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
[System.Serializable]
public static class SavingSystem
{
    public static List<GameData> savedGames = new List<GameData>();
    public static void Save()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            foreach (GameData game in savedGames)
            {
                if(game.username == GameData.session.username)
                {
                    if(game.m_Points < GameData.session.m_Points)
                    {
                        
                        game.m_Points = GameData.session.m_Points;
                        BinaryFormatter bf1 = new BinaryFormatter();
                        FileStream file1 = File.Create(path);
                        bf1.Serialize(file1, SavingSystem.savedGames);
                        file1.Close();
                        Debug.Log("Я обновил счёт игрока: " + GameData.session.username + " на " + game.m_Points);
                    }
                    return;
                }
            }
        }
        Debug.Log("Я сохранил нового игрока: " + GameData.session.username);
        savedGames.Add(GameData.session);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path);
        bf.Serialize(file, SavingSystem.savedGames);
        file.Close();
    }
    public static void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        try
        {
            if (File.Exists(path))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(path, FileMode.Open);
                file.Position = 0;
                SavingSystem.savedGames = (List<GameData>)bf.Deserialize(file);
                file.Close();
            }
            Debug.Log("Я выгрузил отсюда " + " " + path);
        }
        catch 
        { }
    }
    public static void TopPlayer()
    {
        if(savedGames != null)
        {
            var m = 0;
            foreach(GameData game in savedGames)
            {
                if(game.m_Points > m)
                {
                    m = game.m_Points;
                    GameData.session.m_Points = m;
                    GameData.session.username = game.username;
                }
            }
        }
    }
}
