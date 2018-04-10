using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GotoTitleScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }

    public void GotoStoryScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StoryScene");

    }

    //Change GameScene name to what the main game scene has been named as
    public void GotoGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1"); 
    }

    /// ******************************************
    /// Put these 2 below in script where
    /// switch to the Win and Loose scene happens
    /// ******************************************
    public void GotoWinScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("WinScene");
    }

    public void GotoGameOverScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }
}
