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

	static public SceneChangeInfo s_currInfo;

	public void ChangeScene(SceneChangeInfo info)
	{
		if (info.scene_type < SceneTypes.ST_COUNT)
		{
			s_currInfo = info;

			switch(info.scene_type)
			{
				case SceneTypes.ST_OCEAN:
				case SceneTypes.ST_BEACH:
				case SceneTypes.ST_BEACH_GAME:
				case SceneTypes.ST_TEST:
				default: return;
			}
		}
	}
}
