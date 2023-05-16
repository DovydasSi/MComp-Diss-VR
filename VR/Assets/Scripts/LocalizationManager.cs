using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour
{
	static Dictionary<string, string> _localization = new Dictionary<string, string>();

	static List<string> alreadyLoaded = new List<string>();

	void Awake()
	{
		DirectoryInfo dir = new DirectoryInfo("Assets/Resources/Strings");

		FileInfo [] files = dir.GetFiles("*.txt");

		foreach(FileInfo file in files)
		{
			ReadFile("Assets/Resources/Strings/" + file.Name);
		}
	}


	// Start is called before the first frame update
	public static void ReadFile(string filename)
	{
		if (!File.Exists(filename)) return;

		if (alreadyLoaded.Contains(filename)) return;

		StreamReader sr = new StreamReader(filename);

		string line;
		while (!sr.EndOfStream)
		{
			line = sr.ReadLine();
			if (line == null) break;
			if (line.StartsWith("//")) continue;
			string var_name = line;
			string var_value = "";
			while ((line = sr.ReadLine()) != null)
			{
				if (line.StartsWith("//")) continue;
				if (line.StartsWith("---")) break;
				var_value += line;
			}

			if (var_name.Length > 0 && var_value.Length > 0 && !_localization.ContainsKey(var_name))
			{
				_localization.Add(var_name, var_value);
			}
		}

		sr.Close();

		alreadyLoaded.Add(filename);
	}

	public static bool TryLookUpString(string key, out string value)
	{
		return _localization.TryGetValue(key, out value);
	}
}
