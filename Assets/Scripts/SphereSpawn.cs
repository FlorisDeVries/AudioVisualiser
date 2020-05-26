using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawn : MonoBehaviour {

	public GameObject Prefab;
	public float radius;
	void Update () {
		if(Random.Range(0,5) == 0){
			GameObject instance = Instantiate(Prefab);
			Vector2 randomPoint = radius * Random.insideUnitCircle;
			instance.transform.position = new Vector3(transform.position.x + randomPoint.x, transform.position.y + 0, transform.position.z + randomPoint.y);
		}
	}
}
