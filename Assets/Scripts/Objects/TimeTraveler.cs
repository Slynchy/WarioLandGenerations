using UnityEngine;
using System.Collections;

/// <summary>
///  Class for the era-changer object
/// </summary>
public class TimeTraveler : MonoBehaviour {

    [Tooltip("FadeToWhite object prefab")]
    public GameObject FadeToWhite_Prefab;

	// Use this for initialization
	void Start () {
		if (FadeToWhite_Prefab == null)
			Debug.Log ("FadeToWhite prefab not supplied to time traveller!");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeEra()
    {
        GameObject temp = (GameObject)GameObject.Instantiate(FadeToWhite_Prefab);
        temp.GetComponent<FadeToWhiteAndBack>().CallbackFunc = GameObject.Find("Environment").GetComponent<World>().IncEra;
        temp.GetComponent<RectTransform>().SetParent(GameObject.Find("Canvas").transform);
        this.gameObject.GetComponent<AudioSource>().Play();
    }

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "Player") {
            coll.GetComponent<Player>().IncreaseHealth();
            ChangeEra();
		}
	}
}
