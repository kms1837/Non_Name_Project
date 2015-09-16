using UnityEngine;
using System.Collections;

public class PerformanceMgr : MonoBehaviour {


	// Use this for initialization
	void Start () {
		StartCoroutine (test ());
	}
	
	// Update is called once per frame
	void Update () {
	}  

	
	IEnumerator test()
	{
		Time.timeScale = 0.1f;
		Debug.Log("Start Touch Test");

		while (!Input.GetMouseButtonUp(0)) {		
			Debug.Log("BBB");
			//yield return null;
			yield return null;
		}

		Time.timeScale = 1;
		Debug.Log("End Touch Test");

	}


		

}
