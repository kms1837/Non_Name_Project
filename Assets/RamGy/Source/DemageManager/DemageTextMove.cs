using UnityEngine;
using System.Collections;

public class DemageTextMove : MonoBehaviour {

	private bool fadeOutFlag = false;
	private TextMesh textMesh;
	private Color textcolor;


	// Use this for initialization
	void Start () {
		StartCoroutine (FadeOut());
		textMesh  = GetComponent<TextMesh> ();
		textcolor = textMesh.color;
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.up * Time.deltaTime * 2.0f);

		if (fadeOutFlag == true) {
			textcolor.a -= 0.1f;
			textMesh.color = textcolor;
		}

	}

	IEnumerator FadeOut()
	{

		yield return new WaitForSeconds (0.7f);

		fadeOutFlag = true;

		yield return new WaitForSeconds (0.7f);

		Destroy (this.gameObject);

		yield return 0;
	}
}
