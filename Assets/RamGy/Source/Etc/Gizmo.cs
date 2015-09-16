using UnityEngine;
using System.Collections;

public class Gizmo : MonoBehaviour {


	void OnDrawGizmos() {
		Gizmos.color = new Color (0.5f, 0.9f, 1.0f, 0.5f);
		Gizmos.DrawCube (this.transform.position,new Vector3(1.0f,1.0f,1.0f));
	}


}
