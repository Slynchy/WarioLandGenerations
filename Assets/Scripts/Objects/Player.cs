﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    [Tooltip("How high can the player jump? (800 is a good default value)")]
    public float JumpPower;

    /// <summary>
    ///  Is the player grounded?
    /// </summary>
	private bool isGrounded = false;

    /// <summary>
    ///  Rigidbody reference
    /// </summary>
	private Rigidbody2D RB;

    /// <summary>
    ///  References to heart display on HUD
    /// </summary>
	private GameObject[] Hearts;

    [Tooltip("Heart sprites for the eras (GBA, GB, GBC, Atari)")]
    public Sprite[] Heart;
    [Tooltip("No-heart sprites for the eras (GBA, GB, GBC, Atari)")]
    public Sprite[] NoHeart;

    [Tooltip("Starting health for the player?")]
    public uint StartingHealth = 3;
    /// <summary>
    /// Current health of the player
    /// </summary>
	private uint health;

    [Tooltip("Starting score of the player")]
    public uint StartingScore = 0;
    /// <summary>
    ///  Current score of the player
    /// </summary>
	private uint score;

    [Tooltip("Number sprites of the score (0 to 9) *DEPRECATED*")]
    // DEPRECATED
    public Sprite[] ScoreSprites;

    /// <summary>
    /// Reference to smoke trail
    /// </summary>
    private GameObject SmokeTrail;

    /// <summary>
    ///  Sound to play when scoring
    /// </summary>
	private AudioClip ScoreUpSound;

    [Tooltip("Prefab of plus-one popup")]
    public GameObject ScoreUpPrefab;

	IEnumerator LoadGameOver(float time){
		yield return new WaitForSeconds (time);
		SceneManager.LoadScene (2);
	}

	// Use this for initialization
	void Start () {
		RB = this.GetComponent<Rigidbody2D> ();
		Hearts = new GameObject[6];
		Hearts [0] = GameObject.Find ("Heart1");
		Hearts [1] = GameObject.Find ("Heart2");
		Hearts [2] = GameObject.Find ("Heart3");
		Hearts [3] = GameObject.Find ("Heart4");
		Hearts [4] = GameObject.Find ("Heart5");
		Hearts [5] = GameObject.Find ("Heart6");
		health = StartingHealth;
		score = StartingScore;
        SmokeTrail = GameObject.Find("SmokeTrail");
		ScoreUpSound = this.GetComponent<AudioSource> ().clip;
        GameLogic.Init();
		GameLogic.UpdateHighScore((int)score);
		this.GetComponent<WarioVoiceScript> ().PlaySound ("here_i_go1");
    }

	public void IncreaseScore(){
		score++;
		UpdateScoreDisplay ();
		this.GetComponent<WarioVoiceScript> ().PlaySFX (ScoreUpSound);
		GameObject temp = GameObject.Instantiate (ScoreUpPrefab);
		temp.transform.position = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y + 2.0f, this.gameObject.transform.position.z);
	}

    public void UpdateScoreDisplay(){
        GameLogic.UpdateHighScore((int)score);
    }

    public void IncreaseHealth()
    {
        if (health < 6)
            health++;
        UpdateHeartSprites(GameObject.Find("Environment").GetComponent<World>().CurrentEra());
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0 && isGrounded == true)
            {
                RB.AddForce(new Vector2(0, JumpPower));
                isGrounded = false;
                SmokeTrail.SetActive(false);
            }
        }
        else
        {
            if (Input.GetAxis("Jump") > 0 && isGrounded == true)
            {
                RB.AddForce(new Vector2(0, JumpPower));
                isGrounded = false;
                SmokeTrail.SetActive(false);
            }
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            GameObject.FindGameObjectWithTag("TimeTravel").GetComponent<TimeTraveler>().ChangeEra();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameLogic.IncDifficulty();
        }
    }

    void LateUpdate()
    {

    }

	void OnTriggerExit2D(Collider2D coll){
		if (coll.CompareTag ("Obstacle")) {
			IncreaseScore ();
		}
	}

	public void TakeDamage(){
		if (health > 0) {
			health--;
			Hearts [health].GetComponent<Image> ().sprite = NoHeart[(int)GameObject.Find("Environment").GetComponent<World>().CurrentEra()];
			RB.AddForce (new Vector2 (0, 650));
			isGrounded = false;
			SmokeTrail.SetActive(false);
		}
        
		if (health <= 0) {
			this.GetComponent<WarioVoiceScript> ().PlaySound ("scream1");
			this.GetComponent<WarioVoiceScript> ().PlaySound ("Wario_hurt");
			this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			GameObject.Find ("Environment").GetComponent<World> ().StopMoving ();
			StartCoroutine (LoadGameOver (3.0f));
		} else {
			this.GetComponent<WarioVoiceScript> ().PlaySound ("ow_boy");
			this.GetComponent<WarioVoiceScript> ().PlaySound ("Wario_hurt");
		}
	}

	public void UpdateHeartSprites(World.Era _era){
		uint counter = 0;
		foreach (var item in Hearts) {
			if (++counter <= health) {
				item.GetComponent<Image> ().sprite = Heart [(int)GameObject.Find ("Environment").GetComponent<World> ().CurrentEra ()];
			} else {
				item.GetComponent<Image> ().sprite = NoHeart [(int)GameObject.Find ("Environment").GetComponent<World> ().CurrentEra ()];
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag ("Ground")) {
			isGrounded = true;
            SmokeTrail.SetActive(true);
		} else if (coll.gameObject.CompareTag ("Obstacle")) {
			TakeDamage ();
		}
	}
}
