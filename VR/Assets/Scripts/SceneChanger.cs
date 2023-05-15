using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
	[System.Serializable]
	public enum SceneTypes
	{
		ST_MAIN,
		ST_OCEAN,
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
		if ((int)type >= 0 && type < SceneTypes.ST_COUNT)
		{
			s_sceneSetupFilename = setupFilename;

			SceneManager.LoadScene((int)type);
		}
	}

	public static void ChangeScene()
	{
		SceneManager.LoadScene(1);
	}

	public static void ToMainMenu(bool a)
	{
		SceneManager.LoadScene(0);
	}
}
