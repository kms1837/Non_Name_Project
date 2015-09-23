using UnityEngine;
using System.Collections;

public class AITest : MonoBehaviour {
	public  float recognitionTime;
	public  float moveSpeed;
	private bool  recognitionFlag;
	private float direction;
	private float rTimer;
	private GameObject rObj;

	private Vector3 startPosition;

	void Start () {
		recognitionFlag = false;
		startPosition = this.transform.position;
	}

	void Update () {
		if (recognitionFlag) direction = (rObj.transform.position - this.transform.position).x;
		else 				 direction = (startPosition - this.transform.position).x;

		if (Mathf.Abs (direction) > 2) {
			//Move
			if (direction > 0)
				transform.Translate (Vector3.right * Time.deltaTime * moveSpeed, Space.Self);
			else if (direction < 0)
				transform.Translate (Vector3.left * Time.deltaTime * moveSpeed, Space.Self);
		} else {
			//Attack
		};
	}

	void OnTriggerEnter2D(Collider2D collObj) {
		if (collObj.gameObject.tag == "Player") {
			Debug.Log ("인식");
			recognitionFlag = true;
			rTimer = recognitionTime;
			rObj = collObj.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D collObj) {
		if (collObj.gameObject.tag == "Player" && recognitionFlag) {
			Debug.Log ("인식해제중");
			rTimer = rTimer - Time.deltaTime;
			if (rTimer <= 0)
				recognitionFlag = false;
		}
	}
}
