using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public struct ButtonInfo
{
	public SceneChanger.SceneTypes sceneType;
	public string spriteFilename;
	public string buttonName;
	public string setupFilename;
}

public class ButtonSpawner : MonoBehaviour
{
	[SerializeField]
	Transform parentTransform;

	[SerializeField]
	ButtonContent prefabObject;

    // Start is called before the first frame update
    void Start()
    {
		LoadDefaultButtons();


		//LoadButtonsFromFile();
	}

	private void LoadButtonsFromFile()
	{
		string path = "Assets/Scene_Options.json";

		if (!File.Exists(path)) return;

		StreamReader sr = new StreamReader(path, true);
		
		string line = sr.ReadLine();
		if (int.TryParse(line, out int num_of_tests))
		{
			for (int i = 0; i < num_of_tests && (line = sr.ReadLine()) != null; i++)
			{
				ButtonInfo info = JsonUtility.FromJson<ButtonInfo>(line);

				ButtonContent obj = Instantiate(prefabObject, parentTransform);

				//Load data to button
				obj.LoadData(info);
			}
		}
		sr.Close();
	}

	private void LoadDefaultButtons()
	{
		ButtonInfo b = new ButtonInfo();
		b.sceneType = SceneChanger.SceneTypes.ST_OCEAN;
		b.spriteFilename = "Button Sprites/NCL.png";
		b.setupFilename = "";
		b.buttonName = "Named button";

		SaveButtonInfo(b);

		for (int i = 0; i < 2; i++)
		{
			ButtonContent obj = Instantiate(prefabObject, parentTransform);
			obj.LoadData(b);
		}
	}

	// Utility method to generate the JSON file
	public static bool SaveButtonInfo(ButtonInfo info)
	{
		string path = "Assets/Scene_Options.json";

		StreamWriter sw = new StreamWriter(path, false);
		sw.WriteLine(1);

		sw.WriteLine(JsonUtility.ToJson(info));
		sw.Close();

		return true;
	}

	public static bool SaveButtonInfo(ButtonInfo[] info)
	{
		string path = "Assets/Scene_Options.json";

		StreamWriter sw = new StreamWriter(path, false);
		sw.WriteLine(1);
		foreach (ButtonInfo p in info)
		{
			sw.WriteLine(JsonUtility.ToJson(p));
		}

		sw.Close();

		return true;
	}
}
