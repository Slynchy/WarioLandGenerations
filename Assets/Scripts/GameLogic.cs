using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

    public static int highScore;
    private static Sprite[] ScoreSprites;
    static private GameObject[] HighScoreDigits;
    static private GameObject[] ScoreDigits;

    const string SaveDataName = "High Score";

    //adapted from http://stackoverflow.com/questions/4808612/how-to-split-a-number-into-individual-digits-in-c 
    public static int[] GetIntArray(int num)
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

    // Use this for initialization
    void Start () {
    }

   static public void Init()
    {
        if (PlayerPrefs.HasKey(SaveDataName) == false)
        {
            PlayerPrefs.SetInt(SaveDataName, 50);
            highScore = 50;
        }
        else
        { 
            highScore = PlayerPrefs.GetInt(SaveDataName);
        }

        HighScoreDigits = new GameObject[3];
        HighScoreDigits[0] = GameObject.Find("HighScore_3");
        HighScoreDigits[1] = GameObject.Find("HighScore_2");
        HighScoreDigits[2] = GameObject.Find("HighScore_1");
        ScoreDigits = new GameObject[3];
        ScoreDigits[0] = GameObject.Find("Score_3");
        ScoreDigits[1] = GameObject.Find("Score_2");
        ScoreDigits[2] = GameObject.Find("Score_1");

        ScoreSprites = Resources.LoadAll<Sprite>("numbers");
    }

    static public void IncDifficulty()
    {
        GameObject[] backgrounds = GameObject.FindGameObjectsWithTag("Background");
        GameObject[] foregrounds = GameObject.FindGameObjectsWithTag("Foreground");
        GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");

        foreach(GameObject bg in backgrounds)
        {
            bg.GetComponent<Translate>().m_speed_x *= 1.1f;
        }
        foreach (GameObject fg in foregrounds)
        {
            fg.GetComponent<Translate>().m_speed_x *= 1.1f;
        }
        foreach (GameObject g in grounds)
        {
            g.GetComponent<Translate>().m_speed_x *= 1.1f;
        }
    }

    public static void UpdateHighScore(int _score)
    {
        if (highScore < _score)
        {
            highScore = _score;
            PlayerPrefs.SetInt(SaveDataName, _score);
        }

        int[] digits = GameLogic.GetIntArray((int)_score);

        if (digits.Length > 0)
            ScoreDigits[0].GetComponent<Image>().sprite = ScoreSprites[digits[0]];
        if (digits.Length > 1)
            ScoreDigits[1].GetComponent<Image>().sprite = ScoreSprites[digits[1]];
        if (digits.Length > 2)
            ScoreDigits[2].GetComponent<Image>().sprite = ScoreSprites[digits[2]];

        digits = null;
        digits = GameLogic.GetIntArray((int)highScore);

        if (digits.Length > 0)
            HighScoreDigits[0].GetComponent<Image>().sprite = ScoreSprites[digits[0]];
        if (digits.Length > 1)
            HighScoreDigits[1].GetComponent<Image>().sprite = ScoreSprites[digits[1]];
        if (digits.Length > 2)
            HighScoreDigits[2].GetComponent<Image>().sprite = ScoreSprites[digits[2]];
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
