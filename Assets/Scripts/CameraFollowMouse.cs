using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMouse : MonoBehaviour {

    // Speed of the camera movement
    public float camSpeed = 1f;

    // Sensitivity to trigger movement (in pixels)
    public float sensitivity = 2;

    // Flag to keep track of whether we are dragging
    bool isDragging = false;

    // Starting point of a camera rotation
    float startMouseX;
    float startMouseY;

    // Camera component
    Camera cam;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

        // If we press the left button and we haven't started dragging
        if (Input.GetMouseButtonDown(0) && !isDragging)
        {
            // Set the dragging flag to true
            isDragging = true;
            print("started dragging");

            // Save the starting point of the drag
            startMouseX = Input.mousePosition.x;
            startMouseY = Input.mousePosition.y;
        }

        // If we are not pressing the left button and we were dragging
        else if(Input.GetMouseButtonUp(0) && isDragging)
        {
            // Set flag to false as we've stopped dragging
            isDragging = false;
            print("stopped dragging");
        }


//        Camera cam = GetComponent<Camera>();
  //      transform.LookAt(cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane)), Vector3.up);
    }

    // Update the camera rotation
    void LateUpdate()
    {
        // Check that we are currently dragging
        if(isDragging)
        {
            // Calculate current mouse x, y
            float endMouseX = Input.mousePosition.x;
            float endMouseY = Input.mousePosition.y;

            // Difference
            float diffX = endMouseX - startMouseX;
            float diffY = endMouseY - startMouseY;

            // Difference must be higher than the sensitivity
            if( Math.Abs(diffX) > sensitivity || Math.Abs(diffY) > sensitivity)
            {
                // Look at the current center plus this difference
                float lookAtX = Screen.width / 2 + (camSpeed * diffX);
                float lookAtY = Screen.height / 2 + camSpeed * diffY;

                // Rotate the camera
                transform.LookAt(cam.ScreenToWorldPoint(new Vector3(lookAtX, lookAtY, cam.nearClipPlane)), Vector3.up);

                // Starting position for the next frame
                startMouseX = endMouseX;
                startMouseY = endMouseY;
            }           
        }
    }

}
