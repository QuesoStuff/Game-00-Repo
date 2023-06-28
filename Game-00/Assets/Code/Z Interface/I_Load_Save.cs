using UnityEngine;

public interface I_Load_Save
{
    // Save the data from the recordMain object.
    void SaveData(Record_Main recordMain);

    // Load the data into the recordMain object.
    void LoadData(Record_Main recordMain);

    // Load the file data from the save file.
    // Returns the FileData object containing the loaded data.
    FileData LoadFileData();

    // Delete the save file.
    void DeleteSaveFile();
}