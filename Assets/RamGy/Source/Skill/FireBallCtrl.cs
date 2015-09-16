using UnityEngine;
using System.Collections;

public class FireBallCtrl : MonoBehaviour {

	//최대 사정거리
	private float maxRange = 4.0f;
	//발사 확인 
	private bool isShooted = false;


	//시작 지점
	private Vector3 createdPos; 

	public Transform ExploEffect;

	// Use this for initialization
	void Start () {
		createdPos = this.transform.position;
	}

	// Update is called once per frame
	void Update () {

        this.transform.Translate(Vector3.right * Time.deltaTime * 5,Space.Self);
       // this.transform.Rotate(Vector3.forward * Time.deltaTime * (- 80));

		//최대 사거리 도달햇을때 
		if ((this.transform.position - createdPos).magnitude > maxRange && isShooted == false ) 
		{

			Explo();
			isShooted = true;
		}
	}

	void Explo()
	{
		StartCoroutine (this.Explosion());
	}

	IEnumerator Explosion()
	{
		if (ExploEffect != null)
		{
			Transform Effect = (Transform)Instantiate (ExploEffect, this.transform.position, ExploEffect.rotation);
			Destroy (Effect.gameObject, 1);
		}
		Destroy(this.gameObject);
		yield return null;

	}

	void OnTriggerEnter2D(Collider2D other) 	{	
		if (other.gameObject.tag == "Monster") {

			Explo();
			isShooted = true;
			other.SendMessage("GetDemage",300,SendMessageOptions.DontRequireReceiver);
		}
		
	}


}
