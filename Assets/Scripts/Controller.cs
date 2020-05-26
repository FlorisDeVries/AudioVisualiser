using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
	
	void Update () {
		if(Input.GetAxis("Jump") != 0){
			Debug.Log("help");
			SceneManager.LoadScene("MainScene");
		}
	}
}
