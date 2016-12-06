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
	private GameObject[] ScoreDigits;

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
		ScoreDigits = new GameObject[3];
        ScoreDigits[0] = GameObject.Find("Score_3");
        ScoreDigits[1] = GameObject.Find("Score_2");
        ScoreDigits[2] = GameObject.Find("Score_1");
    }

	public void IncreaseScore(){
		score++;
		UpdateScoreDisplay ();
	}

    //adapted from http://stackoverflow.com/questions/4808612/how-to-split-a-number-into-individual-digits-in-c 
    int[] GetIntArray(int num)
    {
        List<int> listOfInts = new List<int>();
        while (num > 0)
        {
            listOfInts.Add(num % 10);
            num = num / 10;
        }
        //listOfInts.Reverse();
        return listOfInts.ToArray();
    }

    public void UpdateScoreDisplay(){
        int[] digits = GetIntArray((int)score);

        ScoreDigits [0].GetComponent<Image> ().sprite = ScoreSprites [digits[0]];

        if(digits.Length > 1)
            ScoreDigits [1].GetComponent<Image>().sprite = ScoreSprites[digits[1]];
        if (digits.Length > 2)
            ScoreDigits [2].GetComponent<Image>().sprite = ScoreSprites[digits[2]];

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
		}

        if(Input.GetKeyDown(KeyCode.K))
        {
            GameObject.FindGameObjectWithTag("TimeTravel").GetComponent<TimeTraveler>().ChangeEra();
        }
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
		} else if (coll.gameObject.CompareTag ("Obstacle")) {
			TakeDamage ();
		}
	}
}
