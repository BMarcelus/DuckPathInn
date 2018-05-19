using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnProximity : MonoBehaviour {

  public GameObject toActivate;
	// Use this for initialization
	void Start () {
		toActivate.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  void OnTriggerEnter(Collider col) {
    toActivate.SetActive(true);
  }
  void OnTriggerExit(Collider col) {
    toActivate.SetActive(false);
  }
}
