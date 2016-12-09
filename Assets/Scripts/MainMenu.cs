using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public World world_obj;

    private float timer;
    public float timer_Cap = 5.0f;

    public GameObject FadeToWhite_Prefab;

	// Use this for initialization
	void Start () {
        timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
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
