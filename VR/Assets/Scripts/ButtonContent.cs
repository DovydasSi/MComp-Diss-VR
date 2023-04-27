using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ButtonContent : MonoBehaviour
{
	[SerializeField]
	Image image;

	[SerializeField]
	Text text;

	string setupPath;

	SceneChanger.SceneTypes sceneType = SceneChanger.SceneTypes.ST_MAIN;

	public void OnClick()
	{
		SceneChanger.ChangeScene(sceneType, setupPath);
		//SceneChanger.ChangeScene();
	}

	public void LoadData(ButtonInfo data)
	{
		sceneType = data.sceneType;
		setupPath = data.setupFilename;

		if (File.Exists("Assets/Resources/" + data.spriteFilename) && data.spriteFilename.Length > 4)
		{
			//Remove extension...
			image.sprite = Resources.Load<Sprite>(data.spriteFilename.Substring(0, data.spriteFilename.Length - 4)); // ugly extension removal all extensions have to be '.' + 3 other characters
		}

		text.text = data.buttonName;
	}
}