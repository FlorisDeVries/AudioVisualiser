using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour {

	public float startScale, maxScale;
	int band;
	
	void Start() {
		band = Random.Range(0,8);
	}
	// Update is called once per frame
	void Update () {
		var value = maxScale * Visualize2.audioBandBuffer[band] + startScale;
		transform.localScale = new Vector3(value, value, value);
	}
}
