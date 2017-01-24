using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {

    /// <summary>
    ///  Loads new game after specified time
    /// </summary>
    /// <param name="time"></param>
	IEnumerator LoadNewGame(float time){
		yield return new WaitForSeconds (time);
		SceneManager.LoadScene (1);
	}
    
	void Start () {
	
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                this.GetComponent<AudioSource>().Stop();
                GameObject.Find("PushSpace").GetComponent<AudioSource>().Play();
                StartCoroutine(LoadNewGame(2.0f));
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.GetComponent<AudioSource>().Stop();
                GameObject.Find("PushSpace").GetComponent<AudioSource>().Play();
                StartCoroutine(LoadNewGame(2.0f));
            }
        }
	}
}
