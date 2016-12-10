using UnityEngine;
using System.Collections;

/// <summary>
///  Rotates the object by N speed every frame
/// </summary>
public class Spin : MonoBehaviour {

    [Tooltip("Speed with which to spin")]
    public float m_speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Rotate (0, 0, m_speed * Time.fixedDeltaTime);
	}
}
