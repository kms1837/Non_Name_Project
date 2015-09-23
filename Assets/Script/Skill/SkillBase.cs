using UnityEngine;
using System.Collections;

public class SkillBase : MonoBehaviour {
	public float maxRange;		// 사정거리
	public float speed;			// 투사체 속도
	public float durationTime;	// 지속 시간
	private bool isShooted = false; // ?
	public Vector3 direction;	// 투사체 방향
	private Vector3 createdPos; // 생성위치
	/*
	void Update () {
		float positionX = this.transform.position.x;
		float maxRange	= Camera.main.rect.xMax + 10;
		float minRange	= Camera.main.rect.xMin - 10;
		
		if(positionX > maxRange || positionX < minRange) Destroy(this.gameObject);
	}
	*/
}
