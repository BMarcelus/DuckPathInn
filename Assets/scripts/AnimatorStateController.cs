using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorStateController : MonoBehaviour {

  public string startState;
  private Animator animator;
  private string lastState;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
    if(startState.Length>1) {
      animator.SetBool("wait", false);    
      animator.SetBool(startState, true);
    }
    lastState = startState;
	}

  public void SetState(string state) {
    animator.SetBool("wait", false);
    if(lastState.Length>1)    
    animator.SetBool(lastState, false);
    animator.SetBool(state, true);
    lastState = state;
  }

  public void FixedUpdate() {
    // if(lastState == "surprise" || lastState == "worried") animator.SetBool("wait", true);
    animator.SetBool("wait", true);
  }
}
