using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeToWhiteAndBack : MonoBehaviour {

	private Image img;
	private bool fadingOut = false;

	// Use this for initialization
	void Start () {
		img = GetComponent < Image > ();
		img.color = new Color (255, 255, 255, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (img.color.a < 1 && fadingOut == false) {
			img.color = new Color (255, 255, 255, img.color.a + (5 * Time.deltaTime));
		} else if (fadingOut == false) {
			fadingOut = true;
			GameObject.Find ("Environment").GetComponent<World> ().ChangeEra (GameObject.Find ("Environment").GetComponent<World> ().CurrentEra()+1);
		} else {
			img.color = new Color (255, 255, 255, img.color.a - (5 * Time.deltaTime));
			if (img.color.a <= 0) {
				Destroy (this.gameObject);
			}
		}
	}
}
