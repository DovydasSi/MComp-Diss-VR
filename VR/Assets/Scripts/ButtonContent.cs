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
	SceneChanger.SceneTypes sceneType;

	public void OnClick()
	{
		SceneChanger.ChangeScene(sceneType, setupPath);
	}

	public void LoadData(ButtonInfo data)
	{
		sceneType = data.sceneType;
		setupPath = data.setupFilename;

		if (File.Exists("Assets/Resources/" + data.spriteFilename) && data.spriteFilename.Length > 4)
		{
			//Remove extension...
			image.sprite = Resources.Load<Sprite>(data.spriteFilename.Substring(0, data.spriteFilename.Length - 4)); // ugly extension removal
		}

		text.text = data.buttonName;
	}
}