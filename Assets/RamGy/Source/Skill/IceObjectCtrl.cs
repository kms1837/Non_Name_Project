using UnityEngine;
using System.Collections;

public class IceObjectCtrl : MonoBehaviour {

	private bool isCrashed = false;


	// Use this for initialization
	void Start () {
		this.transform.Rotate (0, 0, Random.Range(120.0f,60.0f), Space.Self);
		//StartCoroutine (move());
	}
	
	// Update is called once per frame
	void Update () {
		if(isCrashed == false)
			transform.Translate(Vector3.down * Time.deltaTime * 8.0f,Space.Self);

	}

	IEnumerator move()
	{

		yield return null;
	}





	void OnTriggerEnter2D(Collider2D other) 	{	

		if (other.gameObject.tag == "Terrain") {
			isCrashed = true;
			Destroy (this.gameObject, 3);
		}

		if (other.gameObject.tag == "Monster") {
			other.SendMessage("GetDemage",20,SendMessageOptions.DontRequireReceiver);
		}

	}

}
