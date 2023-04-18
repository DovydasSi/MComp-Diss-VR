using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
	Vector3 pos;
	Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
		pos = transform.position;
		rb = GetComponent<Rigidbody>();
    }

    public void ResetPos()
	{
		transform.position = pos;

		rb.angularVelocity = Vector3.zero;
		rb.velocity = Vector3.zero;
	
	}
}
