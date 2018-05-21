using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

  public float jumpForce;
  private Rigidbody rb;

  private int colliding = 0;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Joystick1Button16)) {
    //   if(Grounded()) {
    //     rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
    //   }
    // }
	}

  public void Action() {
    if(Grounded()) {
      rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
    }
  }

  private bool Grounded() {
    return colliding > 0;
  }

  void OnCollisionEnter(Collision col) {
    colliding += 1;
  }
  void OnCollisionExit(Collision col) {
    colliding -= 1;
  }
}
