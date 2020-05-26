using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrollertje : MonoBehaviour {

	public float scrollSpeed, idleScroll;

	void Update () {
		transform.position = new Vector3(transform.position.x, transform.position.y + scrollSpeed * Input.GetAxis("Vertical") + idleScroll, transform.position.z);
	}
}
