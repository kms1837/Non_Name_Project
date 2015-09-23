using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float moveSpeed;

	void Start () {
	
	}

	void Update () {
		float amtMove 	= moveSpeed * Time.deltaTime;//Time.smoothDeltaTime;
		float direction = Input.GetAxis("Horizontal");
		transform.Translate(Vector3.right * amtMove * direction , Space.Self);
	}
}
