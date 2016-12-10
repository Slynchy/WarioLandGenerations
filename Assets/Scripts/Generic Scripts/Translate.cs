using UnityEngine;
using System.Collections;

/// <summary>
///  Translates the object by N speed every frame
/// </summary>
public class Translate : MonoBehaviour {

    [Tooltip("Amount to translate by on X axis")]
    public float m_speed_x;
    [Tooltip("Amount to translate by on Y axis")]
    public float m_speed_y;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Translate ( m_speed_x * Time.fixedDeltaTime,  m_speed_y * Time.fixedDeltaTime, 0);
	}
}
