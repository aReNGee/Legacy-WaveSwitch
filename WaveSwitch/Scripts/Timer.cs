using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float milCount;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
      

    }

    void FixedUpdate()
    {
        UpdateTimerUI();

    }

    public void UpdateTimerUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        milCount = secondsCount % 1000;
        milCount *= 100;
        int tmp = (int)milCount;
        milCount = (float)tmp;
        milCount = milCount / 100;
        timerText.text =  minuteCount + "." + milCount;
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
    }
}
