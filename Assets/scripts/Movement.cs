using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

  public float speed;
  public Animator animator;
  public GameObject model;
  private Vector3 movement = Vector3.zero;
  private Vector3 velocity = Vector3.zero;
  private Rigidbody rb;
  private Quaternion targetAngle;
  private Quaternion modelAngle;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		float verticalInput = Input.GetAxisRaw("Vertical");
    Vector3 inputMovement = new Vector3(horizontalInput, 0, verticalInput);
    bool moving = inputMovement != Vector3.zero;
    if(moving) inputMovement.Normalize();
    movement += (inputMovement - movement)/3;    
    animator.SetBool("walking", moving);
    // model.transform.Rotate(new Vector3(10,0,0));
    animator.SetFloat("WalkSpeed", movement.magnitude);    
    if(moving) {
      targetAngle = Quaternion.LookRotation(inputMovement) * transform.rotation;          
      // model.transform.rotation = Quaternion.Lerp(model.transform.rotation, targetAngle, 0.2f);      
      modelAngle = Quaternion.Lerp(model.transform.rotation, targetAngle, 0.2f);          
    }
    model.transform.rotation = modelAngle;
    if(Input.GetKeyDown(KeyCode.R)) {
      SceneManager.LoadScene("Start3", LoadSceneMode.Single);
    }
	}

  void FixedUpdate() {
    // transform.Translate(movement * speed / 100);
    Vector3 delta = transform.rotation * (movement * speed / 100);
    rb.MovePosition(rb.position + delta);
  }
}
