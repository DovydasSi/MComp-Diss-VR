using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.InputSystem;

public class OceanSceneSetup : MonoBehaviour
{
	[SerializeField]
	public InputActionReference triggerClick;

	[SerializeField]
	GameObject defaultPrefab;

	[SerializeField]
	TextInfoContainer textUI;

	[System.Serializable]
	struct OceanSceneParameters
	{
		string prefab_noExt;
		string info_stringID;
		bool clickable;
		bool grabable;
		bool addSharkAI;
		Vector3 startingPosition;
	}

    // Start is called before the first frame update
    void Start()
    {
        if(SceneChanger.s_sceneSetupFilename != null && SceneChanger.s_sceneSetupFilename.Length > 0)
		{
			ParseSetupFile(SceneChanger.s_sceneSetupFilename);
		}
		else if (defaultPrefab != null)
		{
			GameObject obj = Instantiate(defaultPrefab, transform);
			UIRevealerSetup(ref obj);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void ParseSetupFile(string filename)
	{
		if (!File.Exists("Assets/Resources/Scene Data/" + filename)) return;

		StreamReader sr = new StreamReader("Assets/Resources/Scene Data/" + filename);
		string line;
		while ((line = sr.ReadLine()) != null)
		{
			if (line.StartsWith("//")) continue; // Ignore comments

			if (File.Exists("Assets/Resources/Prefabs/" + line + ".prefab"))
			{
				GameObject obj = Resources.Load<GameObject>("Prefabs/" + line);
				
				obj = Instantiate(obj, transform);


				if (true) // clickable
				{
					UIRevealerSetup(ref obj);
				}
			}
		}
	}

	private void UIRevealerSetup(ref GameObject obj)
	{
		ClickableUIRevealer cuir = obj.GetComponent<ClickableUIRevealer>();
		cuir.infoContainer = textUI;
		cuir.info_text = "sdasdsad";

		// if has a XRSimpleInteractable, setup 
	}
}


