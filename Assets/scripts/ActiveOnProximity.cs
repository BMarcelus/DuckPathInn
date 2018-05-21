using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnProximity : MonoBehaviour {

  public GameObject toActivate;
  public MonoBehaviour[] actionBehaviors;
  public GameObject[] toActivateAction;
  public ActionButtonController actionButton;
  private int actionId;
	// Use this for initialization
	void Start () {
		toActivate.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  void Action() {
    // toActivateAction.SetActive(true);
    for(int i=0;i<toActivateAction.Length;i+=1) {
      toActivateAction[i].SetActive(false);
      toActivateAction[i].SetActive(true);
    }
    for(int i=0;i<actionBehaviors.Length;i+=1) {
      actionBehaviors[i].enabled = true;
    }
    toActivate.SetActive(false);    
  }

  void OnTriggerEnter(Collider col) {
    toActivate.SetActive(true);
    if(actionButton)
    actionId = actionButton.setAction(Action);
  }

  void OnTriggerStay(Collider col) {
    // actionButton.refreshAction(Action, actionId);
  }

  void OnTriggerExit(Collider col) {
    toActivate.SetActive(false);
    actionId = 0;
    for(int i=0;i<toActivateAction.Length;i+=1) {
      toActivateAction[i].SetActive(false);
    }
    for(int i=0;i<actionBehaviors.Length;i+=1) {
      actionBehaviors[i].enabled = false;
    }
    // toActivateAction.SetActive(false);
    if(actionButton)
    actionButton.removeAction(actionId);
  }
}
