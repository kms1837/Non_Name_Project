using UnityEngine;
using System.Collections;

public class LightningBurst : SkillBase {
	public int skillType; //1 - 붙이기, 2 - 터짐
	public Transform explosionEffect;
	
	void Start () {
		maxRange  = 4.0f;
	}
	
	void Update () {
		switch(skillType) {
			case 1:
				this.transform.Translate(direction * Time.deltaTime * speed, Space.Self);
				break;
			case 2:
				durationTime = durationTime - Time.deltaTime;
				if(durationTime < 0) {
					this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
					//임시표식

					Instantiate (explosionEffect, this.transform.position, explosionEffect.rotation);
					Destroy(this);
				}
				break;
		}

		float positionX = this.transform.position.x;
		float maxRange	= Camera.main.rect.xMax + 10;
		float minRange	= Camera.main.rect.xMin - 10;
		
		if(positionX > maxRange || positionX < minRange) Destroy(this.gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D collObj) {
		if (collObj.gameObject.tag == "Enemy" && skillType == 1) {

			collObj.gameObject.GetComponent<SpriteRenderer>().color = new Color(199, 255, 0);
			//임시 표식

			LightningBurst burstObj = collObj.gameObject.AddComponent<LightningBurst>();
			burstObj.skillType	  = 2;
			burstObj.durationTime = 2.0f;
			burstObj.explosionEffect = explosionEffect;
			Destroy(this.gameObject);
		}
	}
}
