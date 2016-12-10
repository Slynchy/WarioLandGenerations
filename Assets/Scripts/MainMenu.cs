using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    [Tooltip("Object that holds the World class in the scene (unique)")]
    public World world_obj;

    // Timer to keep track of time until era change 
    private float timer;

    [Tooltip("How long between era changes (in seconds)?")]
    public float timer_Cap = 5.0f;

    [Tooltip("FadeToWhite object prefab")]
    public GameObject FadeToWhite_Prefab;

    // Reference to start button in scene
    private GameObject StartButton;

    // Loads the game scene after N seconds
	IEnumerator LoadNewGame(float time){
		yield return new WaitForSeconds (time);
		SceneManager.LoadScene (1);
	}
    
	void Start () {
        timer = 0.0f;
        StartButton = GameObject.Find("PushStart");
	}
	
	void Update ()
	{
        // Quit if escape is pressed
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}

        // Play sound + start game if space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
		{
			this.GetComponent<AudioSource> ().Stop ();
			StartButton.GetComponent<AudioSource> ().Play ();
			StartCoroutine (LoadNewGame (2.0f));
        }

        // Count until threshold, then change era and reset counter
        timer += Time.deltaTime;
        if ( timer >= 5.0f )
        {
            GameObject temp = (GameObject)GameObject.Instantiate(FadeToWhite_Prefab);
            temp.GetComponent<FadeToWhiteAndBack>().CallbackFunc = world_obj.IncEra;
            temp.GetComponent<RectTransform>().SetParent(GameObject.Find("Canvas").transform);
            timer = 0.0f;
        }
    }
}
