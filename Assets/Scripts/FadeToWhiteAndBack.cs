using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeToWhiteAndBack : MonoBehaviour {

	private Image img;
	private bool fadingOut = false;

    public delegate void Callback();
    public Callback CallbackFunc;

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
            if (CallbackFunc != null)
                CallbackFunc();
            else
                Debug.Log("No callback function passed to FadeToWhiteAndBack!"); 

        } else {
			img.color = new Color (255, 255, 255, img.color.a - (5 * Time.deltaTime));
			if (img.color.a <= 0) {
				Destroy (this.gameObject);
			}
		}
	}
}
