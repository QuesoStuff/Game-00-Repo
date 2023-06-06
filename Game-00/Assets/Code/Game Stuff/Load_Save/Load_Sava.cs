using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Load_Save
{
    private static string path = Application.persistentDataPath + "/record.data";

    public static void SaveData(Record_Main recordMain)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileData data = new FileData();

        if (File.Exists(path))
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                FileData currentData = formatter.Deserialize(stream) as FileData;
                if (currentData != null)
                {
                    data.DistanceTraveled = Mathf.Max(recordMain.GetDistanceTraveled(), currentData.DistanceTraveled);
                    data.BulletCount = Mathf.Max(recordMain.GetBulletCount(), currentData.BulletCount);
                    data.KillCount = Mathf.Max(recordMain.GetKillCount(), currentData.KillCount);
                    data.TotalDamage = Mathf.Max(recordMain.GetTotalDamage(), currentData.TotalDamage);
                    data.TotalHeal = Mathf.Max(recordMain.GetTotalHeal(), currentData.TotalHeal);
                    data.HighScore = Mathf.Max(recordMain.GetHighScore(), currentData.HighScore);
                    data.ClockTImeMax = Mathf.Max(recordMain.GetClockMax(), currentData.ClockTImeMax);
                    // remember the smaller the timer the longer the time passed
                    data.TimerTimeMax = Mathf.Min(recordMain.GetTimerMax(), currentData.TimerTimeMax);
                }
            }
        }
        else
        {
            data.DistanceTraveled = recordMain.GetDistanceTraveled();
            data.BulletCount = recordMain.GetBulletCount();
            data.KillCount = recordMain.GetKillCount();
            data.TotalDamage = recordMain.GetTotalDamage();
            data.TotalHeal = recordMain.GetTotalHeal();
            data.HighScore = recordMain.GetHighScore();
            data.ClockTImeMax = recordMain.GetClockMax();
            data.TimerTimeMax = recordMain.GetTimerMax();
        }

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }
    }

    public static void LoadData(Record_Main recordMain)
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                FileData data = formatter.Deserialize(stream) as FileData;
                if (data != null)
                {
                    recordMain.SetDistanceTraveled(data.DistanceTraveled);
                    recordMain.SetBulletCount(data.BulletCount);
                    recordMain.SetKillCount(data.KillCount);
                    recordMain.SetTotalDamage(data.TotalDamage);
                    recordMain.SetTotalHeal(data.TotalHeal);
                    recordMain.SetHighScore(data.HighScore);
                }
            }
        }
    }
    public static FileData LoadFileData()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                FileData data = formatter.Deserialize(stream) as FileData;
                return data;
            }
        }
        return null; // Or you might return a new FileData object with default values
    }

    public static void DeleteSaveFile()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
