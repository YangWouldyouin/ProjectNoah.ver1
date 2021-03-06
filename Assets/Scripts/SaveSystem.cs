using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{
	//private static string SavePath => Application.persistentDataPath + "/saves/";
	private static string SavePath => Application.streamingAssetsPath + "/saves/";


	// GameData 
	public static void Save(GameData saveData, string saveFileName)
	{
		if (!Directory.Exists(SavePath))
		{
			Directory.CreateDirectory(SavePath);
		}

		string saveJson = JsonUtility.ToJson(saveData);

		string saveFilePath = SavePath + saveFileName + ".json";
		File.WriteAllText(saveFilePath, saveJson);
		Debug.Log("Save Success: " + saveFilePath);
	}

	public static GameData Load(string saveFileName)
	{
		string saveFilePath = SavePath + saveFileName + ".json";

		if (!File.Exists(saveFilePath))
		{
			Debug.LogError("No such saveFile exists");
			return null;
		}
		string saveFile = File.ReadAllText(saveFilePath);
		GameData saveData = JsonUtility.FromJson<GameData>(saveFile);
		return saveData;
	}

	// SavePageData
	public static void SaveCollectPage(SavePageData savePageData, string saveCollectFileName)
	{
		if (!Directory.Exists(SavePath))
		{
			Directory.CreateDirectory(SavePath);
		}

		string savePageJson = JsonUtility.ToJson(savePageData);

		string saveCollectFilePath = SavePath + saveCollectFileName + ".json";
		File.WriteAllText(saveCollectFilePath, savePageJson);
		Debug.Log("Save Success: " + saveCollectFilePath);
	}

	public static SavePageData LoadCollectPage(string saveCollectFileName)
	{
		string savePageFilePath = SavePath + saveCollectFileName + ".json";

		if (!File.Exists(savePageFilePath))
		{
			Debug.LogError("No such saveFile exists");
			return null;
		}
		string savePageFile = File.ReadAllText(savePageFilePath);
		SavePageData savePageData = JsonUtility.FromJson<SavePageData>(savePageFile);
		return savePageData;
	}
}
