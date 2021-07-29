using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    public int health = 3;
	public float invulnerablePeriod = 2f;
	float invulnerableTimer = 0;
	int correctLayer;
	SpriteRenderer spriteRenderer;

	void Start() {
		correctLayer = gameObject.layer;
		spriteRenderer = GetComponent<SpriteRenderer>();
		if(spriteRenderer == null) {
			spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
			if(spriteRenderer==null) {
				Debug.LogError("Object '"+gameObject.name+"' has no sprite renderer.");
			}
		}
	}

	void OnTriggerEnter2D() {
		health--;
		if(invulnerablePeriod > 0) {
			invulnerableTimer = invulnerablePeriod;
			gameObject.layer = 10;
		}
		if(health <= 0) {
			Destroy(gameObject);
		}
	}

	void Update() {
		if(invulnerableTimer > 0) {
			invulnerableTimer -= Time.deltaTime;
			if(invulnerableTimer <= 0) {
				gameObject.layer = correctLayer;

			}
		}
	}
}
