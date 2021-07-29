using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
	public GameObject bulletPrefabricant;
	public float fireDelay = 0.50f;
	float cooldownTimer = 0;
	Transform player;
    int bulletLayer;

	void Start() {
		bulletLayer = gameObject.layer;
	}

	void Update () {
		if(player == null) {
			GameObject playerGameObject = GameObject.FindWithTag ("Player");
			
			if(playerGameObject != null) {
				player = playerGameObject.transform;
			}
		}
		cooldownTimer -= Time.deltaTime;
		
		if( cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 4) {
			cooldownTimer = fireDelay;
			
			Vector3 offset = transform.rotation * bulletOffset;
			
			GameObject bulletGO = (GameObject)Instantiate(bulletPrefabricant, transform.position + offset, transform.rotation);
			bulletGO.layer = bulletLayer;
		}
	}
}
