using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

  public Transform feetPosition;
  public float jumpForce;
  private Rigidbody rb;

  private int colliding = 0;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Joystick1Button16)) {
      if(Grounded()) {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
      }
    }
    if (Input.GetButtonDown("Fire1")) {
      rb.AddForce(transform.forward * 20, ForceMode.Impulse);
    }
	}

  private bool Grounded() {
    return colliding > 0;
    Ray ray = new Ray();
    ray.origin = feetPosition.position;
    ray.direction = Vector3.down;
    // Debug.DrawRay(ray.origin, ray.direction, Color.red);
    // Debug.DrawLine(ray.origin, ray.origin + ray.direction*.1f,Color.red);
    if(Physics.Raycast(ray, .1f)) {
        // v.y = 30f;
        return true;
    }
    return false;
  }

  void OnCollisionEnter(Collision col) {
    colliding += 1;
  }
  void OnCollisionExit(Collision col) {
    colliding -= 1;
  }
}
