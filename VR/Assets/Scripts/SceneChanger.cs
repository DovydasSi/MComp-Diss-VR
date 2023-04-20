using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
	[System.Serializable]
	public enum SceneTypes
	{
		ST_OCEAN,
		ST_BEACH,
		ST_BEACH_GAME,
		ST_TEST,
		ST_COUNT
	};

	// Remove this probably
	public struct SceneChangeInfo
	{
		public SceneTypes scene_type;
		public string setup_filename;
	}

	static public string s_sceneSetupFilename;

	public static void ChangeScene(SceneTypes type, string setupFilename)
	{
		if (type < SceneTypes.ST_COUNT)
		{
			s_sceneSetupFilename = setupFilename;

			switch(type)
			{
				case SceneTypes.ST_OCEAN: 
				case SceneTypes.ST_BEACH:
				case SceneTypes.ST_BEACH_GAME:
				case SceneTypes.ST_TEST: SceneManager.LoadScene(1); break;
				default: return;
			}
		}
	}

	public static void ChangeScene()
	{
		SceneManager.LoadScene(1);
	}
}
