using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

	public GameObject[] Background_objects;
	public GameObject[] Foreground_objects;
	public GameObject[] Ground_objects;
	private GameObject[] Obstacles;

	public Sprite[] GBC_Sprites;
	public Sprite[] GBA_Sprites;

	public enum Era {
		GameBoyAdv,
		GameBoyCol,
		NUM_OF_ERAS
	}

	private Era current_era = Era.GameBoyAdv;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Era CurrentEra() {
		return current_era;
	}

	public void ChangeEra(Era _era){
		Obstacles = GameObject.FindGameObjectsWithTag ("Obstacle");

		switch (_era) {
			case Era.GameBoyCol:
				SwitchToGBC ();
				break;
			case Era.GameBoyAdv:
				SwitchToGBA ();
				break;
			default:
				break;
		}

		foreach (GameObject obj in Obstacles) {
			obj.GetComponent<ChangeEra_Object> ().ChangeEra (_era);
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
