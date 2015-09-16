using UnityEngine;
using System.Collections;

public class DemageManager : MonoBehaviour {

	public GameObject demageText;


	// Use this for initialization
	void Start () {
		/*
		demageText  =  (GameObject)Resources.Load ("DemageText");
		if (demageText == null) {
			Debug.Log("DemageText is Null");
		}
		demageText.GetComponent<TextMesh>().text = demageText.GetComponent<TextMesh>().text.ToString()+" ";
		*/
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void CreateDemageText(int Value,Transform monsterPos)
	{
		if (demageText == null) {
			Debug.Log ("demageText is null");
		}

		Vector3 demagePosVec = monsterPos.position;
		demagePosVec.x += -1.5f;
		demagePosVec.y += 1.5f;
			

		GameObject demageInstance = (GameObject)Instantiate (demageText,demagePosVec,this.transform.rotation);
		demageInstance.GetComponent<TextMesh> ().text = Value.ToString ();

	
	}
}
