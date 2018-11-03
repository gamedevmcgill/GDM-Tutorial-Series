using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour {

    public float Speed = 5.0f;

    Rigidbody m_rb;
	// Use this for initialization
	void Start () {
        m_rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Animator>().SetBool("IsWalking", m_rb.velocity != Vector3.zero);
	}

    public void Move(Vector2 movement, Vector3 forward, Vector3 right)
    {
        forward.y = right.y = 0;
        m_rb.velocity = (forward * movement.y + right * movement.x).normalized * Speed;

        if(movement != Vector2.zero)
        {
            this.transform.forward = m_rb.velocity;
        }
    }
}
