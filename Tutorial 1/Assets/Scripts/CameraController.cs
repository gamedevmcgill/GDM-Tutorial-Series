using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraController : MonoBehaviour {

    public float pitch;
    public float yaw;

    private Vector2 m_move;

    public float distance;

    public Transform target;

    // Update is called once per frame
    void Update () {
        pitch += m_move.x;
        yaw += m_move.y;

        float x = distance * Mathf.Sin(Mathf.Deg2Rad * pitch) * Mathf.Cos(Mathf.Deg2Rad * yaw);
        float z = distance * Mathf.Sin(Mathf.Deg2Rad * pitch) * Mathf.Sin(Mathf.Deg2Rad * yaw);
        float y = distance * Mathf.Cos(Mathf.Deg2Rad * pitch);

        this.transform.position = new Vector3(x, y, z) + target.position;
        this.transform.LookAt(target);
	}

    public void SetVelocity(float pitch, float yaw)
    {
        m_move.Set(yaw, pitch);
    }

    public void Zoom(float amt)
    {
        distance += amt;
    }
}
