using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {

	IEnumerator LoadNewGame(float time){
		yield return new WaitForSeconds (time);
		SceneManager.LoadScene (1);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	    if(Input.GetKeyDown(KeyCode.Space))
		{
			this.GetComponent<AudioSource> ().Stop ();
			GameObject.Find ("PushSpace").GetComponent<AudioSource> ().Play ();
			StartCoroutine (LoadNewGame (2.0f));
        }
	}
}
