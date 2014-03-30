using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

	public GameObject lookat;
	private Transform mTrans;

	// Use this for initialization
	void Start () 
	{
		mTrans = transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		mTrans.LookAt(lookat.transform);
	}
}
