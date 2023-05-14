using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.IO;
using UnityEngine.InputSystem;

public class OceanSceneSetup : MonoBehaviour
{
	[SerializeField]
	public InputActionReference triggerClick;

	[SerializeField]
	GameObject defaultPrefab;

	[SerializeField]
	TextInfoContainer infoUIContainer;

	[System.Serializable]
	public struct OceanSceneParameters
	{
		public string prefab_noExt;
		public string info_stringID;
		public bool clickable;
		//public bool grabable;
		//public bool addSharkAI;
		//public Vector3 startingPosition;
	}

	// Start is called before the first frame update
	void Start()
    {
		//if (true) { WriteParamsToFile(); } else


        if(SceneChanger.s_sceneSetupFilename != null && SceneChanger.s_sceneSetupFilename.Length > 0)
		{
			ParseSetupFile(SceneChanger.s_sceneSetupFilename);
		}
		else if (defaultPrefab != null)
		{
			GameObject obj = Instantiate(defaultPrefab, transform);
			UIRevealerSetup(ref obj, "");
		}
    }

	private void ParseSetupFile(string filename)
	{
		if (!File.Exists("Assets/Resources/Scene Data/" + filename)) return;

		StreamReader sr = new StreamReader("Assets/Resources/Scene Data/" + filename);
		string line;
		while ((line = sr.ReadLine()) != null)
		{
			if (line.StartsWith("//")) continue; // Ignore comments

			OceanSceneParameters prefab_info = JsonUtility.FromJson<OceanSceneParameters>(line);

			if (File.Exists("Assets/Resources/Prefabs/" + prefab_info.prefab_noExt + ".prefab"))
			{
				GameObject obj = Resources.Load<GameObject>("Prefabs/" + prefab_info.prefab_noExt);
				
				obj = Instantiate(obj, transform);

				if (prefab_info.clickable && LocalizationManager.TryLookUpString("", out string info))
				{
					UIRevealerSetup(ref obj, info);
				}
			}
		}
	}

	private void UIRevealerSetup(ref GameObject obj, string info)
	{
		if (obj.TryGetComponent<XRSimpleInteractable>(out XRSimpleInteractable xrInteractable))
		{
			ClickableUIRevealer cuir;
			if (!obj.TryGetComponent<ClickableUIRevealer>(out cuir))
			{
				cuir = obj.AddComponent<ClickableUIRevealer>();

				xrInteractable.activated.AddListener(delegate { cuir.OnClick(); });
				xrInteractable.deactivated.AddListener(delegate { cuir.OnRelease(); });
			}

			cuir.infoContainer = infoUIContainer;
			cuir.info_text = info;
		}	
	}

	private void WriteParamsToFile()
	{
		StreamWriter sw = new StreamWriter("Assets/Resources/Scene Data/Shark Den.json");

		OceanSceneParameters osp;

		//osp.clickable = true;
		//osp.prefab_noExt = "Whale";
		//osp.info_stringID = "WHALE_INFO";

		//sw.WriteLine(JsonUtility.ToJson(osp));

		osp.clickable = true;
		osp.prefab_noExt = "Shark";
		osp.info_stringID = "SHARK_INFO";

		sw.WriteLine(JsonUtility.ToJson(osp));
		sw.WriteLine(JsonUtility.ToJson(osp));
		sw.WriteLine(JsonUtility.ToJson(osp));
		sw.WriteLine(JsonUtility.ToJson(osp));
		sw.WriteLine(JsonUtility.ToJson(osp));
		sw.WriteLine(JsonUtility.ToJson(osp));

		osp.clickable = false;
		osp.prefab_noExt = "FishSpawner";
		osp.info_stringID = "";

		sw.WriteLine(JsonUtility.ToJson(osp));
		sw.WriteLine(JsonUtility.ToJson(osp));

		sw.Close();
	}
}


