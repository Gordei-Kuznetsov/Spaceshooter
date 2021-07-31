using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float maxSpeed = 6f;
	public float rotSpeed = 180f;
	float shipBoundaryRadius = 0.5f;
	void Update () {
		Quaternion rotation = transform.rotation;
		float zRotaion = rotation.eulerAngles.z;
		zRotaion -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
		rotation = Quaternion.Euler( 0, 0, zRotaion );
		transform.rotation = rotation;

		Vector3 position = transform.position;
		 
		Vector3 transformation = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

		position += rotation * transformation;

		if(position.y+shipBoundaryRadius > Camera.main.orthographicSize) {
			position.y = Camera.main.orthographicSize - shipBoundaryRadius;
		}
		if(position.y-shipBoundaryRadius < -Camera.main.orthographicSize) {
			position.y = -Camera.main.orthographicSize + shipBoundaryRadius;
		}

		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		if(position.x+shipBoundaryRadius > widthOrtho) {
			position.x = widthOrtho - shipBoundaryRadius;
		}
		if(position.x-shipBoundaryRadius < -widthOrtho) {
			position.x = -widthOrtho + shipBoundaryRadius;
		}

		transform.position = position;
    }
}
