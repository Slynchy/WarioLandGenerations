using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public float JumpPower;

	private bool isGrounded = false;

	private Rigidbody2D RB;
	private GameObject[] Hearts;
	public Sprite[] Heart;
	public Sprite[] NoHeart;

	public uint StartingHealth = 3;
	private uint health;

	public uint StartingScore = 0;
	private uint score;
	public Sprite[] ScoreSprites;

    private GameObject SmokeTrail;

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
        GameLogic.Init();
        GameLogic.UpdateHighScore((int)score);
    }

	public void IncreaseScore(){
		score++;
		UpdateScoreDisplay ();
        this.GetComponent<AudioSource>().Play();
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
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded == true) {
			RB.AddForce (new Vector2(0,JumpPower));
			isGrounded = false;
            SmokeTrail.SetActive(false);
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
		}
        
        if(health <= 0)
        {
            RB.AddForce(new Vector2(0, 650));
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            GameObject.Find("Environment").GetComponent<World>().StopMoving();
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

	//void FixedUpdate(){
	//}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag ("Ground")) {
			isGrounded = true;
            SmokeTrail.SetActive(true);
		} else if (coll.gameObject.CompareTag ("Obstacle")) {
			TakeDamage ();
		}
	}
}
