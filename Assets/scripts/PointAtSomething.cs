using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtSomething : MonoBehaviour {

  public GameObject pointObject;
  public float lerp = 1;
  public bool ignoreX, ignoreY, ignoreZ;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    if(pointObject == null)return;
    Vector3 direction = pointObject.transform.position-transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(direction);
    if(ignoreX||ignoreY||ignoreZ) lookRotation = Constrain(lookRotation);
    transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, lerp);
	}

  Quaternion Constrain(Quaternion input) {
    Vector3 eulers = input.eulerAngles;
    Vector3 current = transform.rotation.eulerAngles;
    if(ignoreX) eulers.x = current.x;
    if(ignoreY) eulers.y = current.y;
    if(ignoreZ) eulers.z = current.z;
    return Quaternion.Euler(eulers);
  }
}
