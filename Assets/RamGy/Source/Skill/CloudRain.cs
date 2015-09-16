using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class CloudRain : MonoBehaviour {

	public GameObject RainObject1 = null;


	//SkillInfo myInfo;// = null;

	// Use this for initialization
	void Start () {
		StartCoroutine (shoot ());
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void GetSkillInfo(SkillInfo Info)
	{
		//myInfo = Info;
	}


	IEnumerator shoot()
	{
		System.Random rnd = new System.Random();		
		
		for (int i = 0; i < 10; i ++)
		{
			GameObject temp;
			temp = (GameObject) Instantiate(RainObject1,this.transform.position, this.transform.rotation);
			
			float moveValue 	= (rnd.Next(50)-25)/10;
			int RotateValue = rnd.Next(90)+45;
			
			temp.transform.Translate(moveValue,-0.2f,0,Space.World);
			temp.transform.Rotate(0,0,-1*RotateValue,Space.Self);

			yield return new WaitForSeconds(0.15f);
		}

		yield return 0;
		
	}
}
