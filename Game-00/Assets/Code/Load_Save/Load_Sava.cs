using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Load_Save
{
    // Default path without filename
    private static string basePath = Application.persistentDataPath;

    // Returns the correct file path based on the current mode
    private static string GetFilePath()
    {
        if (Time_Main.GetMode() == CONSTANTS_ENUM.TIME_MODE.TIMER_MODE)
        {
            return Path.Combine(basePath, "timerModeRecord.data");
        }
        else if (Time_Main.GetMode() == CONSTANTS_ENUM.TIME_MODE.CLOCK_MODE)
        {
            return Path.Combine(basePath, "clockModeRecord.data");
        }
        else
        {
            throw new Exception("Invalid time mode for save/load operation");
        }
    }

    public static void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileData data = new FileData();
        // Set data properties here as per your requirements

        string path = GetFilePath(); // use the method to get the correct path

        // We serialize the data into a memory stream first
        using (MemoryStream memoryStream = new MemoryStream())
        {
            formatter.Serialize(memoryStream, data);
            // Now we have a byte array that we can write to disk
            File.WriteAllBytes(path, memoryStream.ToArray());
        }
    }

    public static FileData LoadFileData()
    {
        string path = GetFilePath(); // use the method to get the correct path

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    FileData data = formatter.Deserialize(stream) as FileData;
                    return data;
                }
            }
            catch (Exception e)
            {
                Debug.Log("Failed to deserialize data: " + e.Message);
                // handle or rethrow as necessary
            }
        }
        return null;
    }

    public static void DeleteSaveFile()
    {
        string path = GetFilePath(); // use the method to get the correct path

        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
