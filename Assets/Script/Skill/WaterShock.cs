using UnityEngine;
using System.Collections;

public class WaterShock : SkillBase {
	public  Transform explosionEffect;
	private Transform explosionObj;

	void Start () {
		maxRange  = 4.0f;
	}

	void Update () {
		this.transform.Translate(direction * Time.deltaTime * speed, Space.Self);
	}

	void OnTriggerEnter2D(Collider2D collObj) {
		if (collObj.gameObject.tag == "Enemy") {
			explosionObj = Instantiate (explosionEffect, this.transform.position, explosionEffect.rotation) as Transform;
			Destroy(this.gameObject);
		}
	}
}
