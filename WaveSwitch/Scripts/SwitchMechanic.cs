using UnityEngine;
using System.Collections;

public class SwitchMechanic : MonoBehaviour {

    public int changeState;

    AudioSource audioLow;
    AudioSource audioNorm;
    AudioSource audioHigh;
    AudioSource audioCombo;

    public AudioClip low;
    public AudioClip norm;
    public AudioClip high;
    public AudioClip combo;


    public GameObject[] parts;

    Color c = Color.white;

    public enum WAVESTATE
    {
        NONE,
        RED,
        BLUE,
        YELLOW,
        GREEN,
        ORANGE,
        PURPLE
    }

    public WAVESTATE currentWaveState = WAVESTATE.NONE;

    // Use this for initialization
    void Start () {
        audioLow = gameObject.AddComponent<AudioSource>();
        audioLow.clip = low;
        audioLow.loop = true;
        audioLow.Play();
        audioLow.mute = true;
        audioNorm = gameObject.AddComponent<AudioSource>();
        audioNorm.clip = norm;
        audioNorm.loop = true;
        audioNorm.Play();
        audioNorm.mute = true;
        audioHigh = gameObject.AddComponent<AudioSource>();
        audioHigh.clip = high;
        audioHigh.loop = true;
        audioHigh.Play();
        audioHigh.mute = true;
        audioCombo = gameObject.AddComponent<AudioSource>();
        audioCombo.clip = combo;
        audioCombo.loop = true;
        audioCombo.Play();
        audioCombo.mute = true;
    }
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].gameObject.GetComponent<SpriteRenderer>().color = c;
        }

        //--WAVE STATE

        int switchCounter = 0;

        if (Input.GetKey(KeyCode.Alpha1))
        {
            //red
            switchCounter += 1;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            //blue
            switchCounter += 2;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            //yellow
            switchCounter += 4;
        }

        switch (switchCounter)
        {
            case 0:
                currentWaveState = WAVESTATE.NONE;
                c = Color.white;
                audioLow.mute = true;
                audioNorm.mute = true;
                audioHigh.mute = true;
                audioCombo.mute = true;
                Debug.Log("NO STATE");
                break;

            case 1:
                currentWaveState = WAVESTATE.RED;
                c = Color.red;
                audioLow.mute = false;
                audioNorm.mute = true;
                audioHigh.mute = true;
                audioCombo.mute = true;
                Debug.Log(currentWaveState);
                break;

            case 2:
                currentWaveState = WAVESTATE.BLUE;
                c = Color.blue;
                audioLow.mute = true;
                audioNorm.mute = true;
                audioHigh.mute = false;
                audioCombo.mute = true;
                Debug.Log(currentWaveState);
                break;

            case 3:
                currentWaveState = WAVESTATE.PURPLE;
                c = Color.magenta;
                audioLow.mute = true;
                audioNorm.mute = true;
                audioHigh.mute = true;
                audioCombo.mute = false;
                Debug.Log(currentWaveState);
                break;

            case 4:
                currentWaveState = WAVESTATE.YELLOW;
                c = Color.yellow;
                audioLow.mute = true;
                audioNorm.mute = false;                
                audioHigh.mute = true;
                audioCombo.mute = true;
                Debug.Log(currentWaveState);
                break;

            case 5:
                currentWaveState = WAVESTATE.ORANGE;
                c = new Color(255, 165, 0);
                audioLow.mute = true;
                audioNorm.mute = true;
                audioHigh.mute = true;
                audioCombo.mute = false;
                Debug.Log(currentWaveState);
                break;

            case 6:
                currentWaveState = WAVESTATE.GREEN;
                c = Color.green;
                audioLow.mute = true;
                audioNorm.mute = true;
                audioHigh.mute = true;
                audioCombo.mute = false;
                Debug.Log(currentWaveState);
                break;

            default:
                break;
        }

    }

}
