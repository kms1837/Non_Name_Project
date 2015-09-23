using UnityEngine;
using System.Collections;

public class IceLance : SkillBase {
	public Transform explosionEffect;

	void Start () {
		maxRange  = 4.0f;
	}

	void Update () {
		float positionX = this.transform.position.x;
		float maxRange	= Camera.main.rect.xMax + 10;
		float minRange	= Camera.main.rect.xMin - 10;
		
		if(positionX > maxRange || positionX < minRange) Destroy(this.gameObject);

		this.transform.Translate(direction * Time.deltaTime * speed, Space.Self);
	}
	
	void OnTriggerEnter2D(Collider2D collObj) {
		if (collObj.gameObject.tag == "Enemy") {
			Transform Effect = Instantiate (explosionEffect, this.transform.position, explosionEffect.rotation) as Transform;
		}
	}
}
