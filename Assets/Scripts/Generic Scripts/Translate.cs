using UnityEngine;
using System.Collections;

public class Translate : MonoBehaviour {

	public float m_speed_x;
	public float m_speed_y;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Translate ( m_speed_x * Time.fixedDeltaTime,  m_speed_y * Time.fixedDeltaTime, 0);
	}
}
