using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class SkillList : MonoBehaviour {
	

	public GameObject Panel;

	private GameObject SkillInfoObject;
	private List<GameObject> skillList;

	GameObject AA;


	List<SkillInfo> userSkillList;

	private int x = -330 , y = 90;
	//x + 120 y -120

	// Use this for initialization
	void Start () {

		skillList = new List<GameObject> ();
		userSkillList = DBmanager.GetInstance.ReadUserSkillTable();
		SkillInfoObject = (GameObject)Resources.Load ("SkillList/SkillInfoObject");



		AA =  (GameObject)Instantiate (SkillInfoObject);
		AA.transform.SetParent(this.transform);	
		AA.GetComponent<SkillInfoSetting> ().SetSkillInfo (userSkillList [0]);
		AA.GetComponent<RectTransform> ().localPosition  = new Vector3 (x, y,0);
		skillList.Add (AA);

		x += 120;

		AA =  (GameObject)Instantiate (SkillInfoObject);
		AA.transform.SetParent(this.transform);	
		AA.GetComponent<SkillInfoSetting> ().SetSkillInfo (userSkillList [1]);
		AA.GetComponent<RectTransform> ().localPosition  = new Vector3 (x, y,0);
		AA.transform.SetParent(this.transform);	
		skillList.Add (AA);

		x += 120;

		AA =  (GameObject)Instantiate (SkillInfoObject);
		AA.transform.SetParent(this.transform);	
		AA.GetComponent<SkillInfoSetting> ().SetSkillInfo (userSkillList [2]);
		AA.GetComponent<RectTransform> ().localPosition  = new Vector3 (x, y,0);
		AA.transform.SetParent(this.transform);
		skillList.Add (AA);

	}
	
	// Update is called once per frame
	void Update () {


	}

	//스킬 하나가 클릭되었을때 그 스킬에서 메세지가 올라옴 
	public void SkillClicked(int SkillCode)
	{	
		Debug.Log (SkillCode.ToString()+" is Clicked");
	}

	//스킬 하나가 클릭되었을때 그 스킬에서 메세지가 올라옴 
	public void SkillLongClicked(int SkillCode)
	{	
		Debug.Log (SkillCode.ToString()+" is LongClicked");
	}
}
