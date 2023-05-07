using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public struct ButtonInfo
{
	//public ButtonType buttonType;
	public SceneChanger.SceneTypes sceneType;
	public string spriteFilename;
	public string buttonName;
	public string setupFilename;
}

public enum ButtonType
{
	BT_SCENE_SWITCH,
	BT_DISPLAY_UI,

	BT_COUNT
}

public class ButtonSpawner : MonoBehaviour
{
	[SerializeField]
	Transform parentTransform;

	[SerializeField]
	ButtonContent prefabObject;

    // Start is called before the first frame update
    void Awake()
    {
		//LoadDefaultButtons();


		LoadButtonsFromFile();
		LocalizationManager.ReadFile("Assets/Strings.txt");
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

				obj.transform.SetSiblingIndex(i); // We want these buttons to take priority in the sequence 

				//Load data to button
				obj.LoadData(info);
			}
		}
		sr.Close();
	}

	private void LoadDefaultButtons()
	{
		ButtonInfo b = new ButtonInfo();
		//b.buttonType = ButtonType.BT_SCENE_SWITCH;
		b.sceneType = SceneChanger.SceneTypes.ST_OCEAN;
		b.spriteFilename = "Button Sprites/Whale.jpg";
		b.setupFilename = "Ocean Whale.txt";
		b.buttonName = "Humpaback Whale";

		SaveButtonInfo(b);

		for (int i = 0; i < 2; i++)
		{
			ButtonContent obj = Instantiate(prefabObject, parentTransform);
			obj.LoadData(b);
			obj.transform.SetSiblingIndex(i);
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
