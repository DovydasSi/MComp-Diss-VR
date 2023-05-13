using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickableUIRevealer : MonoBehaviour
{
	public string info_text;
	public TextInfoContainer infoContainer;

	// Start is called before the first frame update
	void Awake()
	{
		//infoContainer = FindObjectOfType<TextInfoContainer>();
	}

	public void OnClick()
	{
		infoContainer.SetText(info_text);
		infoContainer.gameObject.SetActive(true);
	}

	public void OnRelease()
	{
		infoContainer.SetText(info_text);
		infoContainer.gameObject.SetActive(false);
	}
}
