using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public Text hS;
    public Text lS;
    public Text wS;

	// Use this for initialization
	void Start ()
    {
        HSFunction();
        LSFunction();
        WSFunction();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Play()
    {
        SceneManager.LoadScene("Options");
    }

    void HSFunction()
    {
        hS.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    void LSFunction()
    {
        lS.text = PlayerPrefs.GetInt("LastScore").ToString();
    }

    void WSFunction()
    {
        wS.text = PlayerPrefs.GetInt("Wins").ToString();
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instruction3");
    }
}
