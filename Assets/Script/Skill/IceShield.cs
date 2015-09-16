using UnityEngine;
using System.Collections;

public class IceShield : SkillBase {
	public Transform counterSkill;

	void Update () {
		this.transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);
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
			Destroy(this);
		}
	}
}