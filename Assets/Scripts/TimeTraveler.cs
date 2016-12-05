using UnityEngine;
using System.Collections;

public class TimeTraveler : MonoBehaviour {

	public GameObject FadeToWhite_Prefab;

	// Use this for initialization
	void Start () {
		if (FadeToWhite_Prefab == null)
			Debug.Log ("FadeToWhite prefab not supplied to time traveller!");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player") {
			GameObject temp = (GameObject)GameObject.Instantiate (FadeToWhite_Prefab);
			temp.GetComponent<RectTransform> ().SetParent (GameObject.Find ("Canvas").transform);
			this.gameObject.GetComponent<AudioSource> ().Play ();
		}
	}
}
