using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawner : MonoBehaviour
{
	[SerializeField]
	GameObject parentObject;

	[SerializeField]
	GameObject prefabObject;

    // Start is called before the first frame update
    void Start()
    {
        // Parse number of files
		// For each file:
		//		Parse it
		//		Instantiate prefabs under the parent object
		//		Load them with data from the file (Scene type, button sprite filename, scene setup filename)
		//		
    }
}
