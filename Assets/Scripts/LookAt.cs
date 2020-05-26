using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

	public Transform lookAt;
	public Camera camera;
	void Start () {
		camera.transform.LookAt(lookAt);
	}
}
