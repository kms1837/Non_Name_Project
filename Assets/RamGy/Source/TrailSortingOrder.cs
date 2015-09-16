using UnityEngine;
using System.Collections;

public class TrailSortingOrder : MonoBehaviour {

	public string SortingLayerName = "Default";
	public int SortingOrder = 0;

	// Use this for initialization
	void Start () {
		GetComponent<TrailRenderer> ().sortingLayerName = SortingLayerName;
		GetComponent<TrailRenderer> ().sortingOrder = SortingOrder;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
