using UnityEngine;
using System.Collections;

/// <summary>
///  Class for obstacles, and updating their position after going off screen
/// </summary>
public class Obstacle : MonoBehaviour {

    [Tooltip("How far is this obstacle allowed to move from the origin?")]
    public float width_threshold;

    // We want a slight delay so that they don't warp back into view when they've only just left it
    private float timer;
    private const float timer_cap = 2.0f;
    private bool queueUpdate = false;

	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (queueUpdate == true)
        {
            timer += Time.deltaTime;
            if (timer >= timer_cap)
            {
                timer = 0.0f;
                queueUpdate = false;
                this.transform.localPosition = new Vector3(0 + Random.Range(0, width_threshold), this.transform.localPosition.y, this.transform.localPosition.z);
            }
        }
	}

    void OnBecameInvisible()
    {
        queueUpdate = true;
    }
}
