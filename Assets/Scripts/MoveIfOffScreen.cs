using UnityEngine;
using System.Collections;

public class MoveIfOffScreen : MonoBehaviour {

	public Vector2 m_movement;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameInvisible()
	{
		this.transform.Translate (m_movement.x, m_movement.y, 0);
	}
}
