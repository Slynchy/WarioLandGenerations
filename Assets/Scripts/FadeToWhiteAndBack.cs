using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Class for fading image in from full-white/no-alpha to full-white/full-alpha, then back
public class FadeToWhiteAndBack : MonoBehaviour {

    // Image component cache
	private Image img;

    // Is it fading out yet?
	private bool fadingOut = false;

    public delegate void Callback();
    public Callback CallbackFunc;
    
    void Start () {
		img = GetComponent < Image > ();
		img.color = new Color (255, 255, 255, 0);
	}
	
	void Update () {

        // Fade alpha to 255
        //  Execute callback function
        //   Fade to 0
        //    Delete gameobject
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
