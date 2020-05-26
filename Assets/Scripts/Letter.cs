using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour {

	public float startScale, maxScale;
	public int band;
	MeshRenderer mt;
	void Start () {
		mt =  GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(band > 7) {
			transform.localScale = new Vector3(transform.localScale.x, maxScale * Visualize2.amplitudeBuffer + 200, transform.localScale.z);
			return;
		}

		transform.localScale = new Vector3(transform.localScale.x, maxScale * Visualize2.audioBandBuffer[band] + 200, transform.localScale.z);
	}
}
