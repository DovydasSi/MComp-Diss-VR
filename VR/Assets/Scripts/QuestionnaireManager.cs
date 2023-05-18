using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class QuestionnaireManager : MonoBehaviour
{
	[SerializeField]
	GameObject test_objects, completion_objects;
	[SerializeField]
	TMP_Text question_text;
	[SerializeField]
	TestButtonController[] buttons;
	[SerializeField]
	TMP_Text score_text;

	[System.Serializable]
	public struct TestInfo
	{
		public string questionCode;
		public string[] answerCodes;
		public uint correctAnswer;
	}

	List<TestInfo> questions = new List<TestInfo>();
	int testToReveal;
	int score;


    // Start is called before the first frame update
    void Start()
    {

		//if (true) { WriteJSONTestFile("TestQuestions.txt"); } else // just write


		if (SceneChanger.s_sceneSetupFilename != null && SceneChanger.s_sceneSetupFilename.Length > 0)
		{
			ReadJSONTestFile(SceneChanger.s_sceneSetupFilename);
		}
		else
		{
			string filename = "DefaultQuestions.txt";
			WriteJSONTestFile(filename);
			ReadJSONTestFile(filename);
		}

		BeginTest();
    }

	public void BeginTest()
	{
		testToReveal = 0;
		score = 0;
		test_objects.SetActive(true);
		completion_objects.SetActive(false);

		RevealNext();
	}

	void ReadJSONTestFile(string filename)
	{
		if (!File.Exists("Assets/Resources/Test Files/" + filename)) return;

		StreamReader sr = new StreamReader("Assets/Resources/Test Files/" + filename);

		string line;
		while((line = sr.ReadLine()) != null)
		{
			if (line.StartsWith("//")) continue; // Ignore comments
			TestInfo info = JsonUtility.FromJson<TestInfo>(line);

			questions.Add(info);
		}
	}

	void WriteJSONTestFile(string filename)
	{

		StreamWriter sr = new StreamWriter("Assets/Resources/Test Files/" + filename);

		TestInfo info = new TestInfo();
		info.questionCode = "DEFAULT_QUESTION";
		info.answerCodes = new string[4];
		info.answerCodes[0] = "DEFAULT_ANSWER1";
		info.answerCodes[1] = "DEFAULT_ANSWER2";
		info.answerCodes[2] = "DEFAULT_ANSWER3";
		info.answerCodes[3] = "DEFAULT_ANSWER4";
		info.correctAnswer = 4;

		string line = JsonUtility.ToJson(info);
		sr.WriteLine(line);

		info.questionCode = "DEFAULT_QUESTION2";
		line = JsonUtility.ToJson(info);
		sr.WriteLine(line);
		sr.WriteLine(line);

		sr.Close();
	}

	void RevealNext()
	{
		if(testToReveal >= 0 && testToReveal < questions.Count)
		{
			LoadUIText(questions[testToReveal++]);
		}
		else if(testToReveal >= questions.Count)
		{
			// Deactivate test environment on finish
			test_objects.SetActive(false);
			completion_objects.SetActive(true);
			score_text.text = "Score: " + score + "/" + questions.Count; 
		}
	}

	bool LoadUIText(TestInfo info)
	{
		string text;
		if(LocalizationManager.TryLookUpString(info.questionCode, out text))
		{
			question_text.text = text;
		}
		for(int i = 0; i < buttons.Length && i < info.answerCodes.Length; i++)
		{
			if (LocalizationManager.TryLookUpString(info.answerCodes[i], out text))
			{
				buttons[i].SetInfo(text, info.correctAnswer == (i + 1));
			}
		}

		return true;
	}

	public void QuestionAnswered(bool correctly)
	{
		if(correctly)
		{
			// Log Correct answer somehow
			score++;
		}

		foreach(TestButtonController b in buttons)
		{
			b.ResetInfo();
		}
		//RevealNext();
		StartCoroutine("OnAnswer");
	}

	IEnumerator OnAnswer()
	{
		yield return new WaitForSeconds(1.0f);
		RevealNext();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
