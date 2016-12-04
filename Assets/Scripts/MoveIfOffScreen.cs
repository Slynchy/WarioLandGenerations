using UnityEngine;
using System.Collections;

public class MoveIfOffScreen : MonoBehaviour {

	public Vector2 m_movement;

	public uint iterations = 5;

	private uint counter;

	// Use this for initialization
	void Start () {
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameInvisible()
	{
		if (counter == iterations) {
			//Debug.Log ("do stuff");
		}
		this.transform.Translate (m_movement.x, m_movement.y, 0);
		counter++;
	}
}
