using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
	public float angularSpeed = 1f;
	public float circleRad = 1f;

	private Vector3 fixedPoint;
	private float currentAngle;

	void Start()
	{
		fixedPoint = transform.position;
	}

	void Update()
	{
		currentAngle += angularSpeed * Time.deltaTime;
		Vector3 offset = new Vector3(Mathf.Sin(currentAngle), Mathf.Sin(currentAngle), Mathf.Cos(currentAngle)) * circleRad;
		transform.position = fixedPoint + offset;

	}
}
