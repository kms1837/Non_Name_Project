using UnityEngine;
using System.Collections;

public class HpBar : MonoBehaviour {
	public Texture2D hpTexture;
	public Texture2D backTexture;

	public float maxHP;
	public float hp;
	private float originHP;

	private float movePoint;

	private bool moveHPFlag;
	
	Vector2 scrPos;

	void OnGUI(){
		Vector2 scrPos	 = Camera.main.WorldToScreenPoint(transform.position);
		Rect backBarRect = new Rect(scrPos.x - 40, scrPos.y + 60, 80, 20);
		GUI.DrawTexture(backBarRect, backTexture);

		if(maxHP > 0 && hp > 0 && maxHP >= hp) {
			if(movePoint < 0) {
				Rect moveHpBarRect = new Rect(scrPos.x - 40, scrPos.y + 60, (80 / (maxHP/originHP)), 20);
				GUI.color = new Color(0, 0, 0, 0.5f);
				GUI.DrawTexture(moveHpBarRect, hpTexture);

				Rect hpBarRect = new Rect(scrPos.x - 40, scrPos.y + 60, (80 / (maxHP/hp)), 20);
				GUI.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
				GUI.DrawTexture(hpBarRect, hpTexture);

			}else{
				Rect moveHpBarRect = new Rect(scrPos.x - 40, scrPos.y + 60, (80 / (maxHP/hp)), 20);
				GUI.color = new Color(0, 0, 0, 0.5f);
				GUI.DrawTexture(moveHpBarRect, hpTexture);
				
				Rect hpBarRect = new Rect(scrPos.x - 40, scrPos.y + 60, (80 / (maxHP/originHP)), 20);
				GUI.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
				GUI.DrawTexture(hpBarRect, hpTexture);
			}
		}
	}

	// Use this for initialization
	void Start () {
		movePoint  = 0;
		originHP   = maxHP;
		moveHPFlag = false;
	}
	
	// Update is called once per frame
	void Update () {
		movePoint = hp - originHP;
		originHP = originHP + 0.05f * movePoint;
	}
}
