using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour {

    public GameObject Target;

    public float phi;
    public float theta;
    public float distance = 4.0f;

    public float rotateSpeed = 30;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        float x = distance * Mathf.Sin(Mathf.Deg2Rad * theta) * Mathf.Cos(Mathf.Deg2Rad * phi);
        float z = distance * Mathf.Sin(Mathf.Deg2Rad * theta) * Mathf.Sin(Mathf.Deg2Rad * phi);
        float y = distance * Mathf.Cos(Mathf.Deg2Rad * theta);

        this.transform.position = new Vector3(x, y, z) + Target.transform.position;

        this.transform.LookAt(Target.transform);
    }

    public void RotateBy(float theta, float phi)
    {
        this.phi += phi*rotateSpeed;
        this.theta += theta*rotateSpeed;
    }

    public void ZoomBy(float amt)
    {
        distance += amt;
    }
}
