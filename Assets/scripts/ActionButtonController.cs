using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonController : MonoBehaviour {

  public int state;
  public delegate void Action();
  public Action action;
  public Jump jump;  
  private int uuid = 0;
  public int colliding;

	// Use this for initialization
	void Start () {
		action = jump.Action;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Joystick1Button16) || Input.GetButtonDown("Fire1")) {
      action();
    }
	}

  private bool Grounded() {
    return colliding > 0;
  }

  public int setAction(Action newAction) {
    action = newAction;
    uuid += 1;
    state = uuid;
    return uuid;
  }

  public void removeAction(int id) {
    if(id==state) state = 0;
    // uuid = 0;
    action = jump.Action;
  }

  public void refreshAction(Action newAction, int id) {
    if(id>state) {
      state = id;
      action = newAction;
    }
  }

  void OnCollisionEnter(Collision col) {
    colliding += 1;
  }
  void OnCollisionExit(Collision col) {
    colliding -= 1;
  }
}
