using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtSomething : MonoBehaviour {

  public GameObject pointObject;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    Vector3 direction = pointObject.transform.position-transform.position;
		transform.rotation = Quaternion.LookRotation(direction);
	}
}
