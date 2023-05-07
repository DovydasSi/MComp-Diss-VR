using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;

public class XROriginRetriever : MonoBehaviour
{
	[SerializeField]
	XROrigin m_XROrigin;

	// Start is called before the first frame update
	void Start()
	{
		m_XROrigin = FindObjectOfType<XROrigin>();
	}

	public Transform GetXRTransform()
	{
		if (m_XROrigin == null) return null;


		return m_XROrigin.transform;
	}
}
