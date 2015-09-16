using UnityEngine;
using System.Collections;


public class OrangeMushroom : MonsterBase {
	
	System.Random rdm;
	
	
	float waitSecond;
	//특정 이벤트를 실행시키기 위한 시간 카운터 
	float passedTime;
	
	MonsterState nowState;
	//MonsterState beforeState;	
	
	Animator animator;
	
	// Use this for initialization
	new void Start () {

		base.Start();
	
		animator = this.GetComponent<Animator> ();
		
		rdm = new System.Random((int)System.DateTime.Now.Ticks);
		
		nowState 	= MonsterState.Created;
		//beforeState	= MonsterState.Created;
		
		//카운터 초기화
		passedTime = 0;
		waitSecond = 0;
		
		StartCoroutine (BoarAction());
	}
	
	
	void Update () {	

		passedTime += Time.deltaTime;
		
		MoveUpdate ();
	
		if (deadFlag == true) {
			Color colorTemp = GetComponent<SpriteRenderer>().color; 
			colorTemp.a -= 0.003f;
			GetComponent<SpriteRenderer>().color = colorTemp;
		}
	}
	
	IEnumerator BoarAction()
	{	
		//루프 
		while (true) {
			
			if(passedTime > waitSecond)
			{
				waitSecond = (rdm.Next(100)+200)/100;  //결과 2.6  3.5 이런것 나온다.
				passedTime = 0;
				
				//beforeState = nowState;
				
				switch(nowState)
				{
				case MonsterState.Created:
					nowState = MonsterState.Idle;
					break;
					
				case MonsterState.Idle:
					nowState = MonsterState.Run;
					animator.SetTrigger("Attack");
					break;
					
				case MonsterState.Run:
					nowState = MonsterState.Idle;
					animator.SetTrigger("Idle");
					waitSecond += 2.0f;
					break;	
					
				case MonsterState.Hit:
					nowState = MonsterState.Run;
					break;			
				}
			}
			
			//0.1초 간격으로 재호출 
			yield return new WaitForSeconds(0.1f);
		}
	}
	
	
	void MoveUpdate()
	{		
		
		if(nowState == MonsterState.Run)//animator.GetCurrentAnimatorStateInfo(0).IsName("WildBoar_Run"))
			this.transform.Translate(Vector3.left * Time.deltaTime * 1.0f,Space.Self);
		
		else if(nowState == MonsterState.Hit)//animator.GetCurrentAnimatorStateInfo(0).IsName("WildBoar_Hit"))
			this.transform.Translate(Vector3.right * Time.deltaTime * 0.5f,Space.Self);
		
	}

	void Hit()
	{
		nowState	= MonsterState.Hit;
		animator.SetTrigger ("Hit");
		waitSecond = 0.4f;
		passedTime = 0;
	}

	public override void GetDemage(int demageValue)
	{
		demageManager.GetComponent<DemageManager> ().CreateDemageText (demageValue,this.transform);
		Hit ();

		helth -= demageValue;

		if (helth < 1) {
			nowState = MonsterState.Dead;
			animator.SetBool("Dead",true);

			StartCoroutine(Dead());
		}
	}

	IEnumerator Dead()
	{
		yield return new WaitForSeconds (1.0f);
		deadFlag = true;
		Destroy (this.gameObject, 2);

		yield return 0;
	}
	
}
