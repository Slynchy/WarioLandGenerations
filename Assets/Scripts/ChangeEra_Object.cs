using UnityEngine;
using System.Collections;

public class ChangeEra_Object : MonoBehaviour {

	public Sprite gbcSprite;
	public RuntimeAnimatorController gbcAnim;
	public Sprite gbaSprite;
	public RuntimeAnimatorController gbaAnim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void ChangeEra(World.Era _era){
		switch (_era) {
			case World.Era.GameBoyCol:
				this.GetComponent<Animator> ().runtimeAnimatorController = gbcAnim;
				this.GetComponent<SpriteRenderer> ().sprite = gbcSprite;
				break;
			case World.Era.GameBoyAdv:
				this.GetComponent<Animator> ().runtimeAnimatorController = gbaAnim;
				this.GetComponent<SpriteRenderer> ().sprite = gbaSprite;
				break;
			default:
				break;
		}
	}
}
