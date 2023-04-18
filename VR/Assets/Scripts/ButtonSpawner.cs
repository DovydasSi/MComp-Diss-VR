using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public struct ButtonInfo
{
	SceneChanger.SceneTypes sceneType;
	string spriteFilename;
	string setupFilename;
}

public class ButtonSpawner : MonoBehaviour
{
	[SerializeField]
	GameObject parentObject;

	[SerializeField]
	GameObject prefabObject;

    // Start is called before the first frame update
    void Start()
    {
        // Parse number of files
		// For each file:
		//		Parse it
		//		Instantiate prefabs under the parent object
		//		Load them with data from the file (Scene type, button sprite filename, scene setup filename)
		//		
		
		LoadButtonsFromFile();
		
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

				GameObject obj = Instantiate(prefabObject, parentObject.transform);

				//Load data to button
			}
		}
		sr.Close();
	}
}
