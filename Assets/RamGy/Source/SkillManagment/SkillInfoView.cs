using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillInfoView : MonoBehaviour {

	public Image skillImage;
	public Text skillText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GetSkillInfo(SkillInfo Value)
	{
		skillImage.sprite = Resources.Load<Sprite> ("SkillIcon/" + Value.ICon);
		GetComponent<RectTransform> ().localScale = new Vector3 (1.2f, 1.2f, 1.2f);

		skillText.text = "안녕하세양 \n" + Value.name + "\b" + Value.attribute;
	
	}
}
