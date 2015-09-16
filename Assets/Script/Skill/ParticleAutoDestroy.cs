using UnityEngine;
using System.Collections;

public class ParticleAutoDestroy : MonoBehaviour {
	
	void Start () {
		StartCoroutine (Autodestroy ());
	}

	IEnumerator Autodestroy() {
		yield return new WaitForSeconds(this.GetComponent<ParticleSystem>().startLifetime);
		Destroy(this.gameObject);
	}
}
