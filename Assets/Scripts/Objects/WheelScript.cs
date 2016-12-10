using UnityEngine;
using System.Collections;

/// <summary>
///  Script that handles soft-parenting the wheel to the player
/// </summary>
public class WheelScript : MonoBehaviour {

	private Vector3 OrigOffset;
	private Vector3 Offset;

	private GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		OrigOffset = this.transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Offset = new Vector3 (
			OrigOffset.x, 
			//(OrigOffset.y) + (OrigOffset.y * (Player.transform.position.y * 0.3f)), 
			OrigOffset.y,
			OrigOffset.z
		);
		this.transform.position = Player.transform.position + Offset;
	}
}
