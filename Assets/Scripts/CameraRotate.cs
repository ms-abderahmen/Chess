using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private float angle = 0f;
	public float speed = 10f;
	private float x;
	private float z;
    void Update()
    {
        print(transform.position);
        x = 3.5f - 4f * Mathf.Sin (angle);
		z = 3.5f - 4f * Mathf.Cos (angle);
		transform.position = new Vector3(0f,5f,0f);
		transform.rotation = Quaternion.Euler (45, (angle * 180) / (Mathf.PI), 0);
		angle += (2 * Time.deltaTime * Mathf.PI) / speed;
    }
}

