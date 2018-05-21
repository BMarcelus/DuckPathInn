using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidDeathRespawn : MonoBehaviour {

  private Vector3 startPosition;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y<startPosition.y-30) transform.position = startPosition;
	}
}
