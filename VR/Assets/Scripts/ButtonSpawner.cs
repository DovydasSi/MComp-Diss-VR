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
        // Parse number of files
		// For each file:
		//		Parse it
		//		Instantiate prefabs under the parent object
		//		Load them with data from the file (Scene type, button sprite filename, scene setup filename)
		//		
		
		//LoadButtonsFromFile();

		for (int i = 0; i < 11; i++)
		{
			ButtonContent obj = Instantiate(prefabObject, parentTransform);
		}

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
}
