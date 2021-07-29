using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float maxSpeed = 5f;

	void Update () {
		Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
		transform.position += transform.rotation * velocity;
	}
}
