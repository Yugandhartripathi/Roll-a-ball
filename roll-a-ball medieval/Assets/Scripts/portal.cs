using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal: MonoBehaviour {

	public Transform spawnpoint;

	void OnTriggerEnter(Collider other)
	{	
		other.gameObject.transform.position = spawnpoint.position;
	}
}
