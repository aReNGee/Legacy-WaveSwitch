using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

    bool isRunning = true;
    bool isPaused = false;

    //Pause Menu Elements
    public Image screenOverlay;
    public Image PauseMenu;
    public Image resumeButton;
    public Image quitButton;
    public Image pauseControls;

    //Red Frequency Image Selection
    public Image redFreq;
    public Image redFreqSelected;
    public Image redFreqWithYellow;
    public Image redFreqWithBlue;

    //Yellow Frequency Image Selection
    public Image yellowFreq;
    public Image yellowFreqSelected;
    public Image yellowFreqWithRed;
    public Image yellowFreqWithBlue;

    //Blue Frequency Image Selection
    public Image blueFreq;
    public Image blueFreqSelected;
    public Image blueFreqWithRed;
    public Image blueFreqWithYellow;

    /// 1 = Red
    /// 2 = Yellow
    /// 3 = Red + Yellow = Orange
    /// 4 = Blue
    /// 5 = Red + Blue = Purple
    /// 6 = Yellow + Blue  = Green

    // Use this for initialization
    void Start () {
        resetSelection();
        screenOverlay.enabled = false;
        PauseMenu.enabled = false;
        resumeButton.enabled = false;
        quitButton.gameObject.SetActive(false);
        pauseControls.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (isRunning)
        {
            int freq = 0;

            if (Input.GetKey("1"))
            {
                freq += 1;
            }

            if (Input.GetKey("2"))
            {
                freq += 2;
            }

            if (Input.GetKey("3"))
            {
                freq += 4;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = true;
                isRunning = false;
            }

            switch (freq)
            {
                case 1:
                    resetSelection();
                    redFreqSelected.enabled = true;
                    break;
                case 2:
                    resetSelection();
                    yellowFreqSelected.enabled = true;
                    break;
                case 3:
                    resetSelection();
                    redFreqWithYellow.enabled = true;
                    yellowFreqWithRed.enabled = true;
                    break;
                case 4:
                    resetSelection();
                    blueFreqSelected.enabled = true;
                    break;
                case 5:
                    resetSelection();
                    redFreqWithBlue.enabled = true;
                    blueFreqWithRed.enabled = true;
                    break;
                case 6:
                    resetSelection();
                    yellowFreqWithBlue.enabled = true;
                    blueFreqWithYellow.enabled = true;
                    break;
                default:
                    resetSelection();
                    break;
            }
        } else if (isPaused) {
            screenOverlay.enabled = true;
            PauseMenu.enabled = true;
            resumeButton.enabled = true;
            quitButton.gameObject.SetActive(true);
            pauseControls.enabled = true;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                resumeGame();
            }
        }
	}

    void resetSelection()
    {
        redFreqSelected.enabled = false;
        redFreqWithYellow.enabled = false;
        redFreqWithBlue.enabled = false;

        yellowFreqSelected.enabled = false;
        yellowFreqWithRed.enabled = false;
        yellowFreqWithBlue.enabled = false;

        blueFreqSelected.enabled = false;
        blueFreqWithRed.enabled = false;
        blueFreqWithYellow.enabled = false;
    }

    public void resumeGame()
    {
        screenOverlay.enabled = false;
        PauseMenu.enabled = false;
        resumeButton.enabled = false;
        quitButton.gameObject.SetActive(false);
        pauseControls.enabled = false;
        isRunning = true;
        isPaused = false;
    }

    public void quitGame()
    {
        //Enter load menu scene here
    }
}
