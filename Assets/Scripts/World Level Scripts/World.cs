using UnityEngine;
using System.Collections;

public class World : MonoBehaviour {

    /// <summary>
    ///  References to scene objects
    /// </summary>
	private GameObject[] Background_objects;
	private GameObject[] Foreground_objects;
	private GameObject[] Ground_objects;
	private GameObject[] Obstacles;

    /// <summary>
    ///  Reference to player object (unique)
    /// </summary>
	private GameObject Player;


    [Tooltip("GB sprites for background, foreground and ground (respectively)")]
    public Sprite[] GB_Sprites;

    [Tooltip("GBC sprites for background, foreground and ground (respectively)")]
    public Sprite[] GBC_Sprites;

    [Tooltip("GBA sprites for background, foreground and ground (respectively)")]
    public Sprite[] GBA_Sprites;

    [Tooltip("Wii sprites for background, foreground and ground (respectively)")]
    public Sprite[] Wii_Sprites;

    [Tooltip("Atari sprites for background, foreground and ground (respectively)")]
    public Sprite[] Atari_Sprites;

    [Tooltip("Music for each era (GBA, GB, GBC, Atari; in that order)")]
    public AudioClip[] Music;

    /// <summary>
    ///  Enumerators for the eras
    /// </summary>
	public enum Era {
		GameBoyAdv,
		GameBoy,
		GameBoyCol,
		//Wii,
		Atari,
		NUM_OF_ERAS
	}

    /// <summary>
    ///  What is the current era?
    /// </summary>
	private Era current_era = Era.GameBoyAdv;
    
	void Start () {
		Background_objects = GameObject.FindGameObjectsWithTag ("Background");
		Foreground_objects = GameObject.FindGameObjectsWithTag ("Foreground");
		Ground_objects = GameObject.FindGameObjectsWithTag ("Ground");
		Player = GameObject.FindGameObjectWithTag ("Player");
	}

    /// <summary>
    ///  Gets the current era
    /// </summary>
    /// <returns> The current era </returns>
	public Era CurrentEra() {
		return current_era;
	}

    /// <summary>
    ///  Stops moving all objects in scene (for game over)
    /// </summary>
    public void StopMoving()
    {
        foreach (GameObject obj in Background_objects)
        {
            obj.GetComponent<Translate>().m_speed_x = 0;
            obj.GetComponent<Translate>().m_speed_y = 0;
        }
        foreach (GameObject obj in Foreground_objects)
        {
            obj.GetComponent<Translate>().m_speed_x = 0;
            obj.GetComponent<Translate>().m_speed_y = 0;
        }
        foreach (GameObject obj in Ground_objects)
        {
            obj.GetComponent<Translate>().m_speed_x = 0;
            obj.GetComponent<Translate>().m_speed_y = 0;
        }
    }

    /// <summary>
    ///  Increases the current era by 1
    /// </summary>
	public void IncEra(){
		if (++current_era != Era.NUM_OF_ERAS) {
			ChangeEra (current_era);
			GameLogic.IncDifficulty();
		} else {
			ChangeEra (Era.GameBoyAdv);
            current_era = Era.GameBoyAdv;
            GameLogic.IncDifficulty();
        }
	}

    /// <summary>
    ///  Changes the era to the specified era
    /// </summary>
    /// <param name="_era">Era enumerator to change to</param>
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

        if(Player.GetComponent<Player>() != null)
		    Player.GetComponent<Player> ().UpdateHeartSprites (_era);

        if (Camera.main.GetComponent<AudioSource>() != null)
        {
            var time = Camera.main.GetComponent<AudioSource>().time;
            Camera.main.GetComponent<AudioSource>().clip = Music[(int)_era];
			if(Music[(int)_era].length > time)
            	Camera.main.GetComponent<AudioSource>().time = time;
			else
				Camera.main.GetComponent<AudioSource>().time = 0;
            Camera.main.GetComponent<AudioSource>().Play();
        }
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
