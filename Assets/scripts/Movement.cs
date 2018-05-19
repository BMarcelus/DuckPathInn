using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

  public float speed;
  public Animator animator;
  private Vector3 movement = Vector3.zero;
  private Vector3 velocity = Vector3.zero;
  private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		float verticalInput = Input.GetAxisRaw("Vertical");
    Vector3 inputMovement = new Vector3(horizontalInput, 0, verticalInput);
    movement += (inputMovement - movement)/3;
    animator.SetBool("walking", (inputMovement != Vector3.zero));
    // movement = inputMovement;

    // Vector3 inputVelocity = transform.forward*verticalInput*speed;
    // inputVelocity += transform.right*horizontalInput*speed;
    // inputVelocity.y = rb.velocity.y;    
    // rb.velocity = inputVelocity;

    // Vector3 inputVelocity = transform.forward*verticalInput*speed;
    // inputVelocity += transform.right*horizontalInput*speed;
    // velocity += (inputVelocity - velocity)/2;
    // Vector3 outputVelocity = velocity;
    // outputVelocity.y = rb.velocity.y;    
    // rb.velocity = outputVelocity;
    //  rb.AddForce((movement * speed));
    
	}

  void FixedUpdate() {
    // rb.MovePosition(rb.position + movement);
    // rb.AddForce(movement*speed);
    // rb.velocity = new Vector3(translation.x, rb.velocity.y, translation.z);
    transform.Translate(movement * speed / 100);
    // transform.position += movement * speed;
    // transform.position += transform.forward * movement.z * speed;
    // transform.position += transform.right * movement.x * speed;
  }
}
