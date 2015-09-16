using UnityEngine;
using System.Collections;

public class CameraEvent : MonoBehaviour {

	public GameObject myCamera;
	public GameObject myPlayer;

	bool flag;
	//이동거리 
	float distance;
	float nowDistance;
	//속도 
	float speed;

	// Use this for initialization
	void Start () {
		flag = false;

		distance = 30.0f;
		nowDistance = 0.0f;
		speed = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) 	{	

		Debug.Log ("CC");

		if (flag == false) {		
			flag = true;

			StartCoroutine(CameraMove());
		}
	}


	IEnumerator CameraMove()
	{
		myPlayer.SendMessage("SetControl",false,SendMessageOptions.DontRequireReceiver);

		while(nowDistance <= distance)
		{
			Debug.Log ("DD");
			myCamera.transform.Translate(Vector3.right * Time.deltaTime * speed,Space.World);

			nowDistance += (Time.deltaTime * speed);

			yield return null;
		}


		myPlayer.SendMessage("SetControl",true,SendMessageOptions.DontRequireReceiver);
		yield return 0;
	}

}
