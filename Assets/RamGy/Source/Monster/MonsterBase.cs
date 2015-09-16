using UnityEngine;
using System.Collections;


enum MonsterState
{
	Created ,
	Idle 	,
	Run		,
	Attack	,
	Hit		,
	Dead	
};


public class MonsterBase : MonoBehaviour {

	protected GameObject demageManager;

	protected int helth;

	protected bool deadFlag;



	// Use this for initialization
	protected void Start () {

		helth = 200;
		deadFlag = false;

		demageManager = GameObject.Find("DemageManager");
		if (demageManager == null) {
			Debug.Log ("demageManager not loading");
		}

	}
	
	// Update is called once per frame
	void Update () {	
	}

	public virtual void GetDemage(int demageValue)
	{

	}
}
