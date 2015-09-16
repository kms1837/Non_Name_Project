
using UnityEngine;
using System.Collections;


public class PlayerCtrl : MonoBehaviour 
{
    private float h = 0.0f;
    private float v = 0.0f;

    private Transform tr;
	public Rigidbody2D rgdbd;


    public float moveSpeed = 10.0f;
    public float rotSpeed = 10.0f;

    public Transform firePos;

    public GameObject fireBall;
	public GameObject iceRain;

	private MonsterState nowState;
	private MonsterState preStrate;
	private bool StateChangeFlag;

	bool canControl = true;
    
	// Use this for initialization
	void Start () 
    {
        tr 		= GetComponent<Transform>();
		rgdbd = GetComponent<Rigidbody2D> ();

		nowState = MonsterState.Idle;
		preStrate = MonsterState.Idle; 

		StateChangeFlag = false;
        //fireBall = (GameObject)Resources.Load("FireBall", typeof(GameObject));
	}
	
	// Update is called once per frame
	void Update () 
    {
		if (canControl == false)
			return;

		h = Input.GetAxis ("Horizontal");


		if (h != 0) {
			preStrate = nowState;
			nowState = MonsterState.Run;

			if(h < 0)
				transform.rotation = Quaternion.Euler(new Vector3(0,180,0));	

			if(h > 0)
				transform.rotation = Quaternion.Euler(new Vector3(0,0,0));	

		} else {
			preStrate = nowState;
			nowState = MonsterState.Idle; 		
		}



		if (preStrate != nowState) {
			StateChangeFlag = true;
		}

		if (StateChangeFlag == true) {
			switch(nowState)
			{
			case MonsterState.Run:
				GetComponent<Animator>().SetTrigger("Run");
				break;
			case MonsterState.Idle:
				GetComponent<Animator>().SetTrigger("Walk");
				break;
			}
			StateChangeFlag = false;
		}
	


        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        tr.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
        //tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));


		if (Input.GetKeyDown (KeyCode.Space)) {
			Vector3 Temp = this.GetComponent <Rigidbody2D>().velocity;			
			Temp.y = 10.0f;			
			this.GetComponent <Rigidbody2D>().velocity = Temp;
		}


        if (Input.GetMouseButtonDown(0))
        {
		

            FireBall();
			//GameObject dialogManager = GameObject.Find("DialogManager");
			//dialogManager.SendMessage("OnDialog",0,SendMessageOptions.DontRequireReceiver);


        }
		if (Input.GetMouseButtonDown(1))
		{
			IceRain();
			//GameObject dialogManager = GameObject.Find("DialogManager");
			//dialogManager.SendMessage("OnDialog",1,SendMessageOptions.DontRequireReceiver);

		}	

	}

    void FireBall()
    {       
        StartCoroutine(this.Create_FireBall());
    }
    void IceRain()
    {
		StartCoroutine(this.Create_IceRain());
	}

    IEnumerator Create_FireBall()
    {
        Instantiate(fireBall, firePos.position, firePos.rotation);
        yield return null;
    }

	IEnumerator Create_IceRain()
	{
		Instantiate(iceRain, firePos.position, firePos.rotation);
		yield return null;
	}

	IEnumerator PlayerAction()
	{
		while (true) {		
			
			switch(nowState)
			{
			case MonsterState.Created:
				nowState = MonsterState.Idle;
				break;
				
			case MonsterState.Idle:
				nowState = MonsterState.Run;
				//animator.SetTrigger("Attack");
				break;
				
			case MonsterState.Run:
				nowState = MonsterState.Idle;
				//animator.SetTrigger("Idle");
				//waitSecond += 2.0f;
				break;	
				
			case MonsterState.Hit:
				nowState = MonsterState.Run;
				break;
				
				
			}
			yield return 0;
		}
	}

	void SetControl(bool value)
	{
		canControl = value;
	}
}