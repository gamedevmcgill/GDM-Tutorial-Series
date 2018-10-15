using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    public float speed = 5.0f;
    public float turnSpeed = 5.0f;

    private Rigidbody m_rb;

	// Use this for initialization
	void Awake () {
        m_rb = this.GetComponent<Rigidbody>();	
	}
	
    public void Move(Vector3 direction, Vector3 forward, Vector3 right)
    {
        forward.y = right.y = 0;
        m_rb.velocity = (direction.x*forward + direction.z*right).normalized * this.speed;
        this.GetComponentInChildren<Animator>().SetBool("isWalking", direction != Vector3.zero);
        if (direction != Vector3.zero)
        {
            this.transform.forward = m_rb.velocity.normalized;
        }
    }
}
