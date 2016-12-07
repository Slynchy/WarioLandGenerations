using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	public float m_speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Rotate (0, 0, m_speed * Time.fixedDeltaTime);
	}
}
