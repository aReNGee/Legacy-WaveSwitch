using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

    public player player;

    public Vector3 Checkpoint;

   

    // Use this for initialization
    void Start () {
        Checkpoint = player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (!player.isAlive)
        {
            Debug.Log("You died!");
            gameObject.transform.position = Checkpoint;
            player.isAlive = true;

        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("hmm");
        if (col.gameObject.tag == "CheckPoint")
        {
            Debug.Log("Updating Position");
            Checkpoint = col.transform.position;
            Checkpoint += new Vector3(0, 0.2f, 0);
        }
    }
}

