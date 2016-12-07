using UnityEngine;
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
