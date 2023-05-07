using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleOnClick : MonoBehaviour
{
	[SerializeField]
	InputActionReference toggle;

	[SerializeField]
	GameObject toggleObj;
	
    // Start is called before the first frame update
    void Awake()
    {
		toggle.action.started += Toggle;
    }


    private void OnDestroy()
    {
		toggle.action.started -= Toggle;
	}

	private void Toggle(InputAction.CallbackContext context)
	{
		bool is_active = !toggleObj.activeSelf;
		toggleObj.SetActive(is_active);
	}
}
