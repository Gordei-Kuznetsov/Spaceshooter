using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Vector3 bulletOffset = new Vector3(0, 0.6f, 0);
	public GameObject bulletPrefabricant;
	public float fireDelay = 0.1f;
	float cooldownTimer = 0;
    int bulletLayer;

	void Start() {
		bulletLayer = gameObject.layer;
	}

	void Update () {
		cooldownTimer -= Time.deltaTime;

		if( Input.GetButton("Fire1") && cooldownTimer <= 0 ) {
			cooldownTimer = fireDelay;

			Vector3 offset = transform.rotation * bulletOffset;

			GameObject bulletGameObject = (GameObject)Instantiate(bulletPrefabricant, transform.position + offset, transform.rotation);
			bulletGameObject.layer = bulletLayer;
		}
	}
}
