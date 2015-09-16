using UnityEngine;
using System.Collections;
using UnityEditor;

public class SkillManager : MonoBehaviour {

	//private int skillCodeOne = 101;
	//private int skillCodeTwo = 102;

	GameObject skillOne;
	GameObject skillTwo;

	SkillInfo mySkillInfo;

	// Use this for initialization
	void Start () {
	
		skillOne = (GameObject)Resources.Load("Fireball");

		Instantiate (skillOne);


		/*
		 * 프리팹 테스트
		GameObject go = new GameObject("Name of GO");
		go.AddComponent<FireBallCtrl>();
		
		// Create empty prefab and replace with content of `go`.
		Object prefab = PrefabUtility.CreateEmptyPrefab ("Assets/test.prefab");
		PrefabUtility.ReplacePrefab(go, prefab, ReplacePrefabOptions.ConnectToPrefab);
		*/

		GameObject go = new GameObject();
		go.AddComponent<FireBallCtrl>();
		
		// Create prefab from object.
		//PrefabUtility.CreatePrefab("Assets/test.prefab", go, ReplacePrefabOptions.ConnectToPrefab);

		//mySkillInfo = DBmanager.GetInstance.readSkillToCode (skillCodeOne);

		//if (mySkillInfo.scriptCode == 1)
			//skillOne.AddComponent<FireBallCtrl> ();

		//Instantiate (skillOne);
		//mySkillInfo = DBmanager.GetInstance.readSkillToCode (skillCodeTwo);
		//SkillSet (skillOne, mySkillInfo)


	}
	// Update is called once per frame
	void Update () {
	
	}

	void SkillActuation(int Value)
	{
		switch (Value)
		{
		case 1:

			break;
		case 2:
			break;
		case 3:
			break;
		case 4:
			break;
		default:
			break;
		}
	}
	/*
	void FireBall()
	{       
		//this.Create_SkillOne
		StartCoroutine(this.Create_SkillOne());
	}

	IEnumerator Create_SkillOne()
	{
		Instantiate(fireBall, firePos.position, firePos.rotation);
		yield return null;
	}
	*/
}
