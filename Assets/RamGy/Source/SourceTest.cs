using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//만약에 ice rain의 경우
public class SourceTest : MonoBehaviour{

	List<SkillInfo> userSkillList;


	SkillInfo B;

	void Start () {


	
		userSkillList = DBmanager.GetInstance.ReadUserSkillTable();

	

		Debug.Log ( userSkillList[0].ToString ());
	
	

		Debug.Log (userSkillList [1].ToString ());

	

		Debug.Log (userSkillList [2].ToString ());

	}
	
	// Update is called once per frame트
	void Update () {
		
		
	}	

}
