using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageHandler : MonoBehaviour
{
    public int health = 1;
	SpriteRenderer spriteRenderer;

	void Start() {
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
        if(health <= 0) {
			Destroy(gameObject);
		}
	}
}
