using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickableUIRevealer : MonoBehaviour
{
	[SerializeField]
	public InputActionReference triggerClick;

	[SerializeField]
	public GameObject toggleObj;

	public string info_text;
	TextInfoContainer infoContainer;
	Shark sharkComponent;

	// Start is called before the first frame update
	void Awake()
	{
		infoContainer = FindObjectOfType<TextInfoContainer>();
		sharkComponent = gameObject.GetComponent<Shark>();

		triggerClick.action.started += ClickStarted;
		triggerClick.action.performed += ClickEnded;
	}


	private void OnDestroy()
	{
		triggerClick.action.started -= ClickStarted;
		triggerClick.action.performed -= ClickEnded;
	}

	private void ClickStarted(InputAction.CallbackContext context)
	{
		toggleObj.SetActive(true);
		infoContainer.SetText(info_text);
		sharkComponent.enabled = false;
	}

	private void ClickEnded(InputAction.CallbackContext context)
	{
		toggleObj.SetActive(false);

		sharkComponent.enabled = true;
	}
}
