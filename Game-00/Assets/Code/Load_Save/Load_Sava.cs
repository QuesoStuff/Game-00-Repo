using System;
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
                    data.DistanceTraveled_ = Mathf.Max(recordMain.GetDistanceTraveled(), currentData.DistanceTraveled_);
                    data.BulletCount_ = Math.Max(recordMain.GetBulletCount(), currentData.BulletCount_);
                    data.KillCount_ = Math.Max(recordMain.GetKillCount(), currentData.KillCount_);
                    data.TotalDamage_ = Mathf.Max(recordMain.GetTotalDamage(), currentData.TotalDamage_);
                    data.TotalHeal_ = Mathf.Max(recordMain.GetTotalHeal(), currentData.TotalHeal_);
                    data.HighScore_ = Mathf.Max(recordMain.GetHighScore(), currentData.HighScore_);
                    data.ClockTImeMax_ = Mathf.Max(recordMain.GetClockMax(), currentData.ClockTImeMax_);
                    data.TimerTimeMax_ = Mathf.Min(recordMain.GetTimerMax(), currentData.TimerTimeMax_);
                }
            }
        }
        else
        {
            data.DistanceTraveled_ = recordMain.GetDistanceTraveled();
            data.BulletCount_ = recordMain.GetBulletCount();
            data.KillCount_ = recordMain.GetKillCount();
            data.TotalDamage_ = recordMain.GetTotalDamage();
            data.TotalHeal_ = recordMain.GetTotalHeal();
            data.HighScore_ = recordMain.GetHighScore();
            data.ClockTImeMax_ = recordMain.GetClockMax();
            data.TimerTimeMax_ = recordMain.GetTimerMax();
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
                    recordMain.SetDistanceTraveled(data.DistanceTraveled_);
                    recordMain.SetBulletCount(data.BulletCount_);
                    recordMain.SetKillCount(data.KillCount_);
                    recordMain.SetTotalDamage(data.TotalDamage_);
                    recordMain.SetTotalHeal(data.TotalHeal_);
                    recordMain.SetHighScore(data.HighScore_);
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
        return null;
    }

    public static void DeleteSaveFile()
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
