using UnityEngine;
using System.Collections;

public class SpikeCollision : MonoBehaviour {

    public player player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            player.isAlive = false;
        }

    }
}
