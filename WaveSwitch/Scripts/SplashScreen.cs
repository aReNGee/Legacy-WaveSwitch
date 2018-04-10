using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Invoke("LoadScene", 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }
}