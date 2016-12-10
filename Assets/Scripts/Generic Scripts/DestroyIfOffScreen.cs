using UnityEngine;
using System.Collections;

/// <summary>
///  Literally destroys the object as soon as it is no longer drawn
/// </summary>
public class DestroyIfOffScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnBecameInvisible()
	{
		Destroy (this.gameObject);
	}
}
