using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public SaveData data;

    private void Awake()
    {
        instance = this;
    }

    public void Save()
    {
        XmlSerializer formatter = new XmlSerializer(typeof(SaveData));

        if (!Directory.Exists(Application.persistentDataPath + "/GameSaves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/GameSaves");
        }

        string path = Application.persistentDataPath + "/GameSaves/" + "save.xml";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Saved");
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/GameSaves/" + "save.xml";

        if (File.Exists(path))
        {
            XmlSerializer formatter = new XmlSerializer(typeof(SaveData));
            FileStream stream = new FileStream(path, FileMode.Open);

            data = formatter.Deserialize(stream) as SaveData;

            stream.Close();
            Debug.Log("Loaded");

        }
        else
        {
            Debug.Log("No available saves to load! Please create a new save ");
        }
    }
}

[System.Serializable]
public class SaveData
{
    public Vector2 playerPosition;
    public int score;
}
