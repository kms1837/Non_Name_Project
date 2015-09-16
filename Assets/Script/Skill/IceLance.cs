using UnityEngine;
using System.Collections;

public class IceLance : SkillBase {

	public Transform explosionEffect;

	void Start () {
		maxRange  = 4.0f;
	}

	void Update () {
		this.transform.Translate(direction * Time.deltaTime * speed, Space.Self);
	}
	
	void OnTriggerEnter2D(Collider2D collObj) {
		if (collObj.gameObject.tag == "Enemy") {
			Transform Effect = (Transform)Instantiate (explosionEffect, this.transform.position, explosionEffect.rotation);
		}
	}
}
