using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveUsername (GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.dork";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(gameManager);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static SaveData LoadUsername()
    {
        string path = Application.persistentDataPath + "/save.dork";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        } else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }

    public static void DeleteSaveFile()
    {
        File.Delete(Application.persistentDataPath + "/save.dork");
    }
}
