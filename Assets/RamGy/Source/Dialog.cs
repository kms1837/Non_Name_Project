using UnityEngine;
using System.Collections;

public class Dialog : MonoBehaviour {

	private GameObject DialogScreenPrefab;
	private GameObject DialogScreen;

	//대화창이 켜져있는지 여부
	public bool isDialogOn;
	//private int talkCount = 0; 

	// Use this for initialization
	ArrayList talkList = new ArrayList();

	void Awake ()
	{

		DialogScreenPrefab = (GameObject)Resources.Load("DialogScreen");

		isDialogOn = false;
		e = test ();
	}	

	void Update () {

		if (Input.GetKeyDown (KeyCode.A) && isDialogOn == true) {
			e.MoveNext();
		}

	}

	public void OnDialog(int type)
	{
		if (isDialogOn == false) {

			isDialogOn = true;

			DialogScreen = (GameObject)Instantiate (DialogScreenPrefab);

			SetTalkList(type);

		}
	}

	void SetTalkList(int type)
	{
		Debug.Log ("AA");

		switch (type) {
		case 0:
			talkList.Clear();
			talkList.Add("이 마법은 파이어 볼!");
			talkList.Add("강력한 데미지가 특징!");
			talkList.Add("폭팔하기도 하지요! ");
			break;
		case 1:
			talkList.Clear();
			talkList.Add("이 마법은 아이스 레인!");
			talkList.Add("얼음 폭풍이 휘날리지요!");
			talkList.Add("스치기만 해도 아파요!");
			break;
		default:
			break;
		}

		//e = test ();
		e.MoveNext ();
	
	}

	IEnumerator e;
	
	IEnumerator test()
	{
	
		Time.timeScale = 0.1f;

		DialogScreen.GetComponentInChildren<TextMesh>().text = talkList[0].ToString();	
		yield return null;
	
		DialogScreen.GetComponentInChildren<TextMesh>().text = talkList[1].ToString();	
		yield return null;

		DialogScreen.GetComponentInChildren<TextMesh>().text = talkList[2].ToString();
		yield return null;


		isDialogOn = false;
		Time.timeScale = 1;

		e = test ();
		Destroy (DialogScreen);

	}



}
