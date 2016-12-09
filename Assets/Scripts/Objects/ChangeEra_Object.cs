using UnityEngine;
using System.Collections;

public class ChangeEra_Object : MonoBehaviour {

	public Sprite gbSprite;
	public RuntimeAnimatorController gbAnim;
	public Sprite gbcSprite;
	public RuntimeAnimatorController gbcAnim;
	public Sprite gbaSprite;
	public RuntimeAnimatorController gbaAnim;
	public Sprite wiiSprite;
	public RuntimeAnimatorController wiiAnim;
	public Sprite atariSprite;
	public RuntimeAnimatorController atariAnim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void ChangeEra(World.Era _era){
		switch (_era) {
			case World.Era.GameBoy:
                if(gbAnim != null)
				    this.GetComponent<Animator> ().runtimeAnimatorController = gbAnim;
                if (gbSprite != null)
                    this.GetComponent<SpriteRenderer> ().sprite = gbSprite;
				break;
			case World.Era.GameBoyCol:
                if (gbcAnim != null)
                    this.GetComponent<Animator> ().runtimeAnimatorController = gbcAnim;
                if (gbcSprite != null)
                    this.GetComponent<SpriteRenderer> ().sprite = gbcSprite;
				break;
			case World.Era.GameBoyAdv:
                if (gbaAnim != null)
                    this.GetComponent<Animator> ().runtimeAnimatorController = gbaAnim;
                if (gbaSprite != null)
                    this.GetComponent<SpriteRenderer> ().sprite = gbaSprite;
				break;
			//case World.Era.Wii:
			//	this.GetComponent<Animator> ().runtimeAnimatorController = wiiAnim;
			//	this.GetComponent<SpriteRenderer> ().sprite = wiiSprite;
			//	break;
			case World.Era.Atari:
                if (atariAnim != null)
                    this.GetComponent<Animator>().runtimeAnimatorController = atariAnim;
                if (atariSprite != null)
                    this.GetComponent<SpriteRenderer>().sprite = atariSprite;
                break;
			default:
				break;
		}
	}
}
