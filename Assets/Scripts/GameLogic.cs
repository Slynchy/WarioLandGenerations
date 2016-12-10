using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

    /// <summary>
    ///  Current high score, statically accessible
    /// </summary>
    public static int highScore;

    /// <summary>
    ///  Sprites of number digits from 0 to 9
    /// </summary>
    private static Sprite[] ScoreSprites;

    /// <summary>
    ///  References to the score display digits in the scene
    /// </summary>
    static private GameObject[] HighScoreDigits;
    static private GameObject[] ScoreDigits;

    /// <summary>
    ///  Name of save data key as a constant
    /// </summary>
    const string SaveDataName = "High Score";

    /// <summary>
    ///  Initial starting difficulty
    /// </summary>
	private const float BaseDifficulty = 2.5f;

    //adapted from http://stackoverflow.com/questions/4808612/how-to-split-a-number-into-individual-digits-in-c 
    public static int[] GetIntArray(int num)
    {
        List<int> listOfInts = new List<int>();
        while (num > 0)
        {
            listOfInts.Add(num % 10);
            num = num / 10;
        }
        return listOfInts.ToArray();
    }

    // Use this for initialization
    void Start () {
    }

    /// <summary>
    ///  Initializes all the static variables/references
    /// </summary>
   static public void Init()
    {
        // Check if savedata exists
        //  Initialize if not
        //  Load if it does
        if (PlayerPrefs.HasKey(SaveDataName) == false)
        {
            PlayerPrefs.SetInt(SaveDataName, 50);
            highScore = 50;
        }
        else
        { 
            highScore = PlayerPrefs.GetInt(SaveDataName);
        }

        // Cache the score objects in scene
        HighScoreDigits = new GameObject[3];
        HighScoreDigits[0] = GameObject.Find("HighScore_3");
        HighScoreDigits[1] = GameObject.Find("HighScore_2");
        HighScoreDigits[2] = GameObject.Find("HighScore_1");
        ScoreDigits = new GameObject[3];
        ScoreDigits[0] = GameObject.Find("Score_3");
        ScoreDigits[1] = GameObject.Find("Score_2");
        ScoreDigits[2] = GameObject.Find("Score_1");

        // Load score sprites from Resources folder
        ScoreSprites = Resources.LoadAll<Sprite>("numbers");

        // Increase the difficulty by base amount
		IncDifficulty(-1 * BaseDifficulty);
        // It is negative because of the way the difficulty is handled
    }

    /// <summary>
    ///  Increase difficulty by the predefined amount
    /// </summary>
    static public void IncDifficulty()
    {
		const float difficultyIncrease = -0.75f;

        GameObject[] backgrounds = GameObject.FindGameObjectsWithTag("Background");
        GameObject[] foregrounds = GameObject.FindGameObjectsWithTag("Foreground");
        GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");

        foreach(GameObject bg in backgrounds)
        {
			bg.GetComponent<Translate>().m_speed_x += difficultyIncrease;
        }
        foreach (GameObject fg in foregrounds)
        {
			fg.GetComponent<Translate>().m_speed_x += difficultyIncrease;
        }
        foreach (GameObject g in grounds)
        {
			g.GetComponent<Translate>().m_speed_x += difficultyIncrease;
        }
	}

    /// <summary>
    ///  Increases difficulty by specified amount
    /// </summary>
    /// <param name="_inc"></param>
	static public void IncDifficulty(float _inc)
	{
		GameObject[] backgrounds = GameObject.FindGameObjectsWithTag("Background");
		GameObject[] foregrounds = GameObject.FindGameObjectsWithTag("Foreground");
		GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");

		foreach(GameObject bg in backgrounds)
		{
			bg.GetComponent<Translate>().m_speed_x += _inc;
		}
		foreach (GameObject fg in foregrounds)
		{
			fg.GetComponent<Translate>().m_speed_x += _inc;
		}
		foreach (GameObject g in grounds)
		{
			g.GetComponent<Translate>().m_speed_x += _inc;
		}
	}

    // Update high score display with the current high score
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
