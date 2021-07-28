using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
	
	void Update () {
		if(target != null) {
			Vector3 targetPosition = target.position;
			targetPosition.z = transform.position.z;
			transform.position = targetPosition;
		}
	}
}
