using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {

  public float horizontalSensitivity;
  public float verticalSensitivity;
  public Transform CameraPivotX;
  public Transform CameraPivotY;
	// Use this for initialization
	void Start () {		
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
    if (Input.GetMouseButtonDown(0)) {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }
    if(Input.GetKeyDown(KeyCode.Escape)) {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible=true;
    }
    float xAxis = Input.GetAxisRaw("Mouse X") * horizontalSensitivity;
    float yAxis = Input.GetAxisRaw("Mouse Y") * verticalSensitivity;
    xAxis += Input.GetAxisRaw("Joystick2H") * horizontalSensitivity;
    yAxis += -Input.GetAxisRaw("Joystick2V") * verticalSensitivity;
    CameraPivotX.Rotate(new Vector3(0, xAxis, 0));
    // CameraPivotY.Rotate(new Vector3(yAxis, 0, 0));
    Vector3 rot = CameraPivotY.rotation.eulerAngles;
    rot.x -= verticalSensitivity*yAxis;
    float minAngle = 60;
    float maxAngle = -20;
    if(rot.x > 180) rot.x -= 360;
    if(rot.x < maxAngle) rot.x = maxAngle;
    if(rot.x > minAngle) rot.x = minAngle;
    // if (rot.x > minAngle && rot.x < 90) rot.x = minAngle;
    // if (rot.x > 360 - 90 && rot.x < 360 - maxAngle) rot.x = 360 - maxAngle;
    CameraPivotY.rotation = Quaternion.Euler(rot.x, rot.y, rot.z);
	}
}
