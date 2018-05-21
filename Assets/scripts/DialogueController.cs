using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour {
  [System.Serializable]
  public class Dialogue {
    public string text;
    public string faceAnimation;
    public string bodyAnimation;
    public GameObject lookAt;
    public GameObject faceTowards;
  }
  public Dialogue[] dialogues;
  // public string[] texts;

  public TextMesh textMesh;
  public AnimatorStateController faceAnimator;
  public AnimatorStateController bodyAnimator;
  public PointAtSomething headPoint;
  public GameObject bodyPivot;
  public int repeat = -1;
  private int dialogueIndex = -1;
  private int textIndex = 0;
  private Dialogue dialogue;
  private string currentText = "";
  private int currentLength = 0;
  private bool typing = false;

	// Use this for initialization
	void Start () { 
	}
	
	void FixedUpdate () {
    if(dialogue.text == "") {
      textIndex += 1;
      typing = false;
      if(textIndex>30) {
        NextDialogue();
      }
      return;
    }
    if(textIndex == 0) {
      textMesh.text = "";
      currentLength = 0;
      typing = true;
    }
    if(textIndex < dialogue.text.Length) {
      typing = true;
      char c = dialogue.text[textIndex];
      // currentText += c;
      // if(c == ' ' && currentLength > 16) {
      if (c == '/') {
        textMesh.text += '\n';
        currentLength = 0;
      } else {
        textMesh.text += c;
      }
      currentText = textMesh.text;
      // currentLength += 1;
      textIndex += 1;
    } else {
      typing = false;
    }
    // textMesh.text = dialogue.text.Substring(0, textIndex);
    // if (textIndex < dialogue.text.Length) textIndex += 1;   
	}

  void OnEnable() {
    NextDialogue();
  }

  void OnDisable() {
    textMesh.text = "";
  }

  private void CloseDialogueWindow() {
    gameObject.SetActive(false);    
  }

  private void OpenDialogueWindow() {
    gameObject.SetActive(true);
  }
  
  private void NextDialogue() {
    if(typing) {
      // FixedUpdate();
      textMesh.text = currentText;
      return;
      // dialogueIndex -= 1;
    } 
    dialogueIndex += 1;
    if(dialogueIndex >= dialogues.Length) {
      if(repeat >= 0) {
        dialogueIndex = repeat-1;
      } else {
        dialogueIndex -= 2;
      }
      textIndex = 0;      
      textMesh.text = "";      
      CloseDialogueWindow();
      return;
    }
    dialogue = dialogues[dialogueIndex];
    // if(dialogue.text == "") CloseDialogueWindow();
    // else OpenDialogueWindow();    
    textIndex = 0;
    if(dialogue.faceAnimation.Length>1) faceAnimator.SetState(dialogue.faceAnimation);
    if(dialogue.bodyAnimation.Length>1) bodyAnimator.SetState(dialogue.bodyAnimation);
    // if(dialogue.lookAt != null) headPivot.transform.rotation = Quaternion.LookRotation(dialogue.lookAt.transform.position-headPivot.transform.position);
    // if(dialogue.faceTowards != null) bodyPivot.transform.rotation = Quaternion.LookRotation(dialogue.faceTowards.transform.position-bodyPivot.transform.position);
    if(dialogue.lookAt != null) headPoint.pointObject = dialogue.lookAt;
    // headPoint.pointObject = dialogue.lookAt;
  }
}
