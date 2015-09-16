using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillInfoSetting : MonoBehaviour {

	private SkillInfo skillInfo;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void onClick()
	{

		this.transform.parent.SendMessage ("SkillClicked", skillInfo.skillCode, SendMessageOptions.DontRequireReceiver);

		//this.transform.parent.GetComponent<SkillList> ().ViewInfo (skillInfo.skillCode);
		//GameObject.Find ("SKILL_INFO").GetComponent<SkillInfoView> ().GetSkillInfo (this.skillInfo);
	}

	public void onLongClick()
	{
		this.transform.parent.SendMessage ("SkillLongClicked", skillInfo.skillCode, SendMessageOptions.DontRequireReceiver);
	}

	public void SetSkillInfo(SkillInfo Value)
	{
		skillInfo = Value;

		Debug.Log ("Called");
		GetComponent<Image> ().sprite = Resources.Load<Sprite> ("SkillIcon/" + skillInfo.ICon);
		GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);

	}



}
