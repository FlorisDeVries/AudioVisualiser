using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RikRensen : MonoBehaviour {

	public GameObject R, I, K, E, N, S;
	
	public float width = .5f;

	public float startScale;
	public float maxScale;

	private GameObject[] nameSpelled;
	private bool spelled = false;

	void Update () {
		if(spelled)
			return;
		Quaternion turnAround = new Quaternion(0,180,0, 0);
		nameSpelled = new GameObject[9]{
			 Instantiate(R, transform.position + new Vector3(-4*width,0,0), turnAround)
			,Instantiate(I, transform.position + new Vector3(-3*width,0,0), turnAround)
			,Instantiate(K, transform.position + new Vector3(-2*width,0,0), turnAround)
			,Instantiate(R, transform.position + new Vector3(0,0,0), turnAround)
			,Instantiate(E, transform.position + new Vector3(width,0,0), turnAround)
			,Instantiate(N, transform.position + new Vector3(2*width,0,0), turnAround)
			,Instantiate(S, transform.position + new Vector3(3*width,0,0), turnAround)
			,Instantiate(E, transform.position + new Vector3(4*width,0,0), turnAround)
			,Instantiate(N, transform.position + new Vector3(5*width,0,0), turnAround)
		};

		for (int i = 0; i < nameSpelled.Length; i++) {
			nameSpelled[i].AddComponent<Letter>().band = i;
		}
		spelled =true;
	}
}
