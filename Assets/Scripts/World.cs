using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

	private GameObject[] Background_objects;
	private GameObject[] Foreground_objects;
	private GameObject[] Ground_objects;
	private GameObject[] Obstacles;

	private GameObject Player;

	public Sprite[] GB_Sprites;
	public Sprite[] GBC_Sprites;
	public Sprite[] GBA_Sprites;
	public Sprite[] Wii_Sprites;
	public Sprite[] Atari_Sprites;

	public AudioClip[] Music;

	public enum Era {
		GameBoyAdv,
		GameBoy,
		GameBoyCol,
		//Wii,
		Atari,
		NUM_OF_ERAS
	}

	private Era current_era = Era.GameBoyAdv;

	// Use this for initialization
	void Start () {
		Background_objects = GameObject.FindGameObjectsWithTag ("Background");
		Foreground_objects = GameObject.FindGameObjectsWithTag ("Foreground");
		Ground_objects = GameObject.FindGameObjectsWithTag ("Ground");
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Era CurrentEra() {
		return current_era;
	}

	public void IncEra(){
		if (++current_era != Era.NUM_OF_ERAS) {
			ChangeEra (current_era);
		} else {
			ChangeEra (Era.GameBoyAdv);
            current_era = Era.GameBoyAdv;

        }
	}

	public void ChangeEra(Era _era){
		Obstacles = GameObject.FindGameObjectsWithTag ("Obstacle");

		switch (_era) {
			case Era.GameBoy:
				SwitchToGB ();
			break;
			case Era.GameBoyCol:
				SwitchToGBC ();
				break;
			case Era.GameBoyAdv:
				SwitchToGBA ();
			break;
			//case Era.Wii:
			//	SwitchToWii ();
			//	break;
			case Era.Atari:
				SwitchToAtari ();
				break;
			default:
				break;
		}

		foreach (GameObject obj in Obstacles) {
			obj.GetComponent<ChangeEra_Object> ().ChangeEra (_era);
		}
		Player.GetComponent<ChangeEra_Object> ().ChangeEra (_era);

		Player.GetComponent<Player> ().UpdateHeartSprites (_era);

		var time = Camera.main.GetComponent<AudioSource> ().time;
		Camera.main.GetComponent<AudioSource> ().clip = Music [(int)_era];
		Camera.main.GetComponent<AudioSource> ().time = time;
		Camera.main.GetComponent<AudioSource> ().Play ();
	}

	private void SwitchToGB(){
		current_era = Era.GameBoy;
		foreach (GameObject obj in Background_objects) {
			obj.GetComponent<SpriteRenderer> ().sprite = GB_Sprites [0];
		}
		foreach (GameObject obj in Foreground_objects) {
			obj.GetComponent<SpriteRenderer> ().sprite = GB_Sprites [1];
		}
		foreach (GameObject obj in Ground_objects) {
			obj.GetComponent<SpriteRenderer> ().sprite = GB_Sprites [2];
		}
	}

	private void SwitchToWii(){
		//current_era = Era.Wii;
		foreach (GameObject obj in Background_objects) {
			obj.GetComponent<SpriteRenderer> ().sprite = Wii_Sprites [0];
		}
		foreach (GameObject obj in Foreground_objects) {
			obj.GetComponent<SpriteRenderer> ().sprite = Wii_Sprites [1];
		}
		foreach (GameObject obj in Ground_objects) {
			obj.GetComponent<SpriteRenderer> ().sprite = Wii_Sprites [2];
		}
	}

	private void SwitchToAtari(){
		//current_era = Era.Wii;
		foreach (GameObject obj in Background_objects) {
			obj.GetComponent<SpriteRenderer> ().sprite = Atari_Sprites [0];
		}
		foreach (GameObject obj in Foreground_objects) {
			obj.GetComponent<SpriteRenderer> ().sprite = Atari_Sprites [1];
		}
		foreach (GameObject obj in Ground_objects) {
			obj.GetComponent<SpriteRenderer> ().sprite = Atari_Sprites [2];
		}
	}

	private void SwitchToGBC(){
		current_era = Era.GameBoyCol;
		foreach (GameObject obj in Background_objects) {
			obj.GetComponent<SpriteRenderer> ().sprite = GBC_Sprites [0];
		}
		foreach (GameObject obj in Foreground_objects) {
			obj.GetComponent<SpriteRenderer> ().sprite = GBC_Sprites [1];
		}
		foreach (GameObject obj in Ground_objects) {
			obj.GetComponent<SpriteRenderer> ().sprite = GBC_Sprites [2];
		}
	}

	private void SwitchToGBA(){
		current_era = Era.GameBoyAdv;
		foreach (GameObject obj in Background_objects) {
			obj.GetComponent<SpriteRenderer> ().sprite = GBA_Sprites [0];
		}
		foreach (GameObject obj in Foreground_objects) {
			obj.GetComponent<SpriteRenderer> ().sprite = GBA_Sprites [1];
		}
		foreach (GameObject obj in Ground_objects) {
			obj.GetComponent<SpriteRenderer> ().sprite = GBA_Sprites [2];
		}
	}
}
