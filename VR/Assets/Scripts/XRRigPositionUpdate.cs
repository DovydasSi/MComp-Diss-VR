using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRRigPositionUpdate : MonoBehaviour
{
	[SerializeField]
	XROriginRetriever retriever;

	public Transform camRig;

	private void LateUpdate()
	{
		if (camRig != null)
		{
			camRig.position = transform.position;
			camRig.rotation.Set(camRig.rotation.x, transform.rotation.y, camRig.rotation.z, camRig.rotation.w);
		}
	}

	public void AttachRig()
	{
		camRig = retriever.GetXRTransform();
		Debug.Log("Attached Rig");
	}

	public void DetachRig()
	{
		Debug.Log("Dettached Rig");
		camRig = null;
	}
}
