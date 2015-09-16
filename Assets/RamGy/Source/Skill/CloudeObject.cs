using UnityEngine;
using System.Collections;

public class CloudeObject : MonoBehaviour {

	public float speed;
	bool isCrashed = false;

	// Use this for initialization
	void Start () {
		speed = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (isCrashed == false) {
			this.transform.Translate (Vector3.right * Time.deltaTime * speed, Space.Self);
		}
	}




	void OnTriggerEnter2D(Collider2D other) 	{

		isCrashed = true;			
		Destroy (this.gameObject, 3);

	}
}
