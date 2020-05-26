using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickDown : MonoBehaviour {

	public int minLife, maxLife;

	private float life;
	private float timer = 0;
	MeshRenderer mr;
	void Start () {
		life = Random.Range(minLife, maxLife);
		mr = GetComponent<MeshRenderer>();
		Color color = new Color(Random.Range(0, .8f), Random.Range(0,.8f), Random.Range(0, .8f));
		mr.material.SetColor("_Color", color);
		mr.material.SetColor("_Emission", color);
	}
	void Update () {
		if(timer > life){
			Debug.Log("Destroyed");
			Destroy(this);
		}
		timer += Time.deltaTime;
	}
}
