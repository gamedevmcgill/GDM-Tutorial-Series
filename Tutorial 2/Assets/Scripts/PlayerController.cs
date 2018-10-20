using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class PlayerController : MonoBehaviour {

    private MovementController m_mover;
    private CameraController m_camera;

    //Mouse Variables
    private Vector2 m_delta;
    private Vector2 m_currentMousePos;
    private Vector2 m_lastMousePos;

	// Use this for initialization
	void Start () {
        m_currentMousePos = m_lastMousePos;
        m_mover = this.GetComponent<MovementController>();
        m_camera = Camera.main.gameObject.GetComponent<CameraController>();
	}
	
	void Update () {
        //Move Player
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        m_mover.Move(new Vector2(x, y), m_camera.transform.forward, m_camera.transform.right);

        //Move Camera

        m_currentMousePos = Input.mousePosition;

        if(Input.GetMouseButton(1))
        {
            m_delta = m_currentMousePos - m_lastMousePos;
            m_delta.x /= Screen.currentResolution.width;
            m_delta.y /= Screen.currentResolution.height;
        }
        else
        {
            m_delta = Vector2.zero;
        }
        

        m_lastMousePos = m_currentMousePos;

        m_camera.RotateBy(m_delta.y, m_delta.x);
        m_camera.ZoomBy(-1*Input.GetAxis("Mouse ScrollWheel"));
    }
}
