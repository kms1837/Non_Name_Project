using UnityEngine;
using System.Collections;

public class IceRainCtrl : MonoBehaviour {

	//최대 발사개수
	private int maxNiddle = 15;
	//발사 시간
	private float maxShootSecond = 1.0f;
	//발사 확인 
	private bool isShooted = false;		
	//시작 지점
	private Vector3 createdPos; 
	//얼음 오브젝트 
	public GameObject iceObject;
	//얼음 생성위치 이펙트 
	private GameObject iceCreatEffect;

	//얼음 오브젝트 리스
	private ArrayList IceObjectList = new ArrayList();

	private delegate void updateDele();
	updateDele myUpdateDele = null;
	
	// Use this for initialization 스킬을 사용할때마다 리소스 로드를 퍼포먼스에 문제가 생길수도
	void Start () {
		iceObject = (GameObject)Resources.Load ("IceObject");

		createdPos = this.transform.position;

		//위치 올리기
		//createdPos.y += 3.0f;

		iceCreatEffect = (GameObject)Resources.Load ("IceCreatePos");
		iceCreatEffect = (GameObject)Instantiate (iceCreatEffect, createdPos, this.gameObject.transform.rotation);
	}
	
	// Update is called once per frame트
	void Update () {

		if(iceCreatEffect != null)
			iceCreatEffect.transform.Rotate (0, 0, 75.0f * Time.deltaTime, Space.Self);

		if (isShooted == false) {
			niddleMake();
			isShooted = true;
		}

		if (myUpdateDele != null)
			myUpdateDele ();
	}

	void niddleMake()
	{
		StartCoroutine (this.NiddleShoot());
	}
	
	IEnumerator NiddleShoot()
	{
		for (int i = 0; i < maxNiddle; i ++) {
			GameObject temp = (GameObject)Instantiate (iceObject, createdPos, this.gameObject.transform.rotation);

			IceObjectList.Add(temp);
			yield return new WaitForSeconds (maxShootSecond / (float)maxNiddle);
		}		

		Destroy (iceCreatEffect,1.1f);

		myUpdateDele += SmallEffect;
		yield return new WaitForSeconds (1);	
		myUpdateDele -= SmallEffect;

		iceCreatEffect = null;
		Destroy (this.gameObject,1.0f);


		yield return null;
	}

	void SmallEffect()
	{

		Vector3 scaleVector = iceCreatEffect.transform.localScale;

		scaleVector.x = scaleVector.x - 1.0f * Time.deltaTime;
		scaleVector.y = scaleVector.y - 1.0f * Time.deltaTime;

		iceCreatEffect.transform.localScale = scaleVector;



	}




}
