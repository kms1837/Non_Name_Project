using UnityEngine;
using System.Collections;

public class SkillBase : MonoBehaviour {
	public float maxRange;
	public float speed;
	public float durationTime;
	private bool isShooted = false;
	public Vector3 direction;
	private Vector3 createdPos;
}
