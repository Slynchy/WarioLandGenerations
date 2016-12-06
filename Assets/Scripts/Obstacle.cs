using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    public float width_threshold;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnBecameInvisible()
    {
        this.transform.localPosition = new Vector3(0 + Random.Range(0, width_threshold), this.transform.localPosition.y, this.transform.localPosition.z);
    }
}
