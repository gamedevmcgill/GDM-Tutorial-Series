using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private PlayerMovement m_mover;
    public CameraController cam;

    private Vector2 lastMousePos;
    private Vector2 delta;
    private Vector2 mousePos;

    private bool hold = false;
    // Use this for initialization
    void Start () {
        m_mover = this.GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    { 
        mousePos = Input.mousePosition;

        if(Input.GetMouseButton(1))
        {
            delta = mousePos - lastMousePos;
            delta.x /= Screen.currentResolution.width;
            delta.y /= Screen.currentResolution.height;
            delta *= 250;
        }
        else
        {
            delta = Vector2.zero;
        }

        lastMousePos = mousePos;

        cam.SetVelocity(-1.0f*delta.x, delta.y);
        cam.Zoom(-1.0f*Input.GetAxis("Mouse ScrollWheel"));
        m_mover.Move(new Vector3(Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal")), cam.transform.forward, cam.transform.right);
    }
}
