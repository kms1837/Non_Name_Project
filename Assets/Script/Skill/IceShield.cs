using UnityEngine;
using System.Collections;

public class IceShield : SkillBase {
	public Transform counterSkill;
	public Sprite shieldTexture;
	private GameObject shieldObj;

	void Start () {
		SpriteRenderer setSprite;
		shieldObj = new GameObject("shield");
		shieldObj.transform.parent = this.transform;

		setSprite = shieldObj.AddComponent<SpriteRenderer>();
		setSprite.sprite		= shieldTexture;
		setSprite.sortingOrder  = 2;
	}

	void Update () {
		durationTime = durationTime - Time.deltaTime;
		shieldObj.transform.position = this.transform.position;

		if (durationTime < 0){
			Destroy (shieldObj);
			Destroy (this);
		}
	}
	
	void OnTriggerEnter2D(Collider2D collObj) {
		if (collObj.gameObject.tag == "bullet") {
			float	collX 	  	 = collObj.transform.position.x;
			Bounds  shieldBound  = this.gameObject.GetComponent<Renderer>().bounds;
			Vector3 shieldPos 	 = this.transform.position;
			Vector3 insPosition;
			Vector3 setDirection;

			if(this.transform.position.x > collX) {
				insPosition  = new Vector3(shieldBound.min.x - 1, shieldPos.y, shieldPos.z);
				setDirection = new Vector3(-1, 0, 0);

			} else {
				insPosition  = new Vector3(shieldBound.max.x + 1, shieldPos.y, shieldPos.z);
				setDirection = new Vector3(1, 0, 0);
			}

			Transform Effect = (Transform)Instantiate (counterSkill, insPosition, counterSkill.rotation);
			Effect.GetComponent<WaterShock>().direction = setDirection;
			Effect.GetComponent<WaterShock>().speed = collObj.gameObject.GetComponent<SkillBase>().speed;
			Destroy(shieldObj);
			Destroy(this);
		}
	}
}