using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickableUIRevealer : MonoBehaviour
{
	public string info_text;
	public TextInfoContainer infoContainer;
	Rigidbody rigidbody;

	// Start is called before the first frame update
	void Awake()
	{
		//infoContainer = FindObjectOfType<TextInfoContainer>();

		rigidbody = GetComponent<Rigidbody>();
	}

	public void OnClick()
	{
		infoContainer.SetText(info_text);
		infoContainer.gameObject.SetActive(true);

		if(rigidbody != null)
		{
			rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
		}
	}

	public void OnRelease()
	{
		infoContainer.SetText(info_text);
		infoContainer.gameObject.SetActive(false);

		if (rigidbody != null)
		{
			rigidbody.constraints = RigidbodyConstraints.None;
		}
	}
}
