using UnityEngine;
using System.Collections;

public class GateCollision : MonoBehaviour {
    public player player;
    public SwitchMechanic switchMechanic;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D col)
    {

        //-- Gate Checking

        if (col.gameObject.tag == "RedGate")
        {
            if (switchMechanic.currentWaveState == SwitchMechanic.WAVESTATE.RED)
            {
                Debug.Log("YOU DID IT");
            }
            else
            {
                Debug.Log("YOU DIED");
                player.isAlive = false;
            }
        }

        if (col.gameObject.tag == "BlueGate")
        {
            if (switchMechanic.currentWaveState == SwitchMechanic.WAVESTATE.BLUE)
            {
                Debug.Log("YOU DID IT");
            }
            else
            {
                Debug.Log("YOU DIED");
                player.isAlive = false;
            }
        }

        if (col.gameObject.tag == "YellowGate")
        {
            if (switchMechanic.currentWaveState == SwitchMechanic.WAVESTATE.YELLOW)
            {
                Debug.Log("YOU DID IT");
            }
            else
            {
                Debug.Log("YOU DIED");
                player.isAlive = false;
            }
        }

        if (col.gameObject.tag == "PurpleGate")
        {
            if (switchMechanic.currentWaveState == SwitchMechanic.WAVESTATE.PURPLE)
            {
                Debug.Log("YOU DID IT");
            }
            else
            {
                Debug.Log("YOU DIED");
                player.isAlive = false;
            }
        }

        if (col.gameObject.tag == "OrangeGate")
        {
            if (switchMechanic.currentWaveState == SwitchMechanic.WAVESTATE.ORANGE)
            {
                Debug.Log("YOU DID IT");
            }
            else
            {
                Debug.Log("YOU DIED");
                player.isAlive = false;
            }
        }

        if (col.gameObject.tag == "GreenGate")
        {
            if (switchMechanic.currentWaveState == SwitchMechanic.WAVESTATE.GREEN)
            {
                Debug.Log("YOU DID IT");
            }
            else
            {
                Debug.Log("YOU DIED");
                player.isAlive = false;
            }
        }

        //--
    }
}
