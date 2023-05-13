using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestButtonController : MonoBehaviour
{
	[SerializeField]
	TMP_Text buttonText;

	[SerializeField]
	Button button;

	[SerializeField]
	QuestionnaireManager questionnaireManager;

	bool is_correct;



    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
		
    }


    public void OnClick()
    {
		if(is_correct)
		{
			
		}

		questionnaireManager.QuestionAnswered(is_correct);
    }

	public void ResetInfo()
	{
		is_correct = false;
		buttonText.text = "";
		button.enabled = false;
	}

	public void SetInfo(string text, bool correct)
	{
		is_correct = correct;
		buttonText.text = text;
		button.enabled = true;
	}
}
