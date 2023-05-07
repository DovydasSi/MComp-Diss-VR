using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextInfoContainer : MonoBehaviour
{
	[SerializeField]
	TMP_Text text;

	[SerializeField]
	ScrollRect scrollRect;

	public void SetText(string new_text)
	{
		scrollRect.verticalNormalizedPosition = 0;
		text.text = new_text;
	}
}
