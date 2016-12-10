using UnityEngine;
using System.Collections;

/// <summary>
///  Class to attach to objects that change sprite with the era
/// </summary>
public class ChangeEra_Object : MonoBehaviour {

    [Tooltip("Sprite to have in Gameboy era")]
    public Sprite gbSprite;
    [Tooltip("Animator to have in Gameboy era")]
    public RuntimeAnimatorController gbAnim;

    [Tooltip("Sprite to have in Gameboy Colour era")]
    public Sprite gbcSprite;
    [Tooltip("Sprite to have in Gameboy Colour era")]
    public RuntimeAnimatorController gbcAnim;

    [Tooltip("Sprite to have in Gameboy Advance era")]
    public Sprite gbaSprite;
    [Tooltip("Sprite to have in Gameboy Advance era")]
    public RuntimeAnimatorController gbaAnim;

    [Tooltip("Sprite to have in Wii era")]
    public Sprite wiiSprite;
    [Tooltip("Sprite to have in Wii era")]
    public RuntimeAnimatorController wiiAnim;

    [Tooltip("Sprite to have in Atari era")]
    public Sprite atariSprite;
    [Tooltip("Sprite to have in Atari era")]
    public RuntimeAnimatorController atariAnim;
    
	void Start () {
		
	}
	
	void Update () {
		
	}

    /// <summary>
    ///  Changes era of this object
    /// </summary>
    /// <param name="_era">Era enumerator to change to</param>
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
