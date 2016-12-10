using UnityEngine;
using System.Collections;

/// <summary>
///  Moves the object by XY if no longer drawn
/// </summary>
public class MoveIfOffScreen : MonoBehaviour {

    [Tooltip("Amount to translate by when offscreen")]
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
