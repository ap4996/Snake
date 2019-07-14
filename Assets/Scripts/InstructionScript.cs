using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionScript : MonoBehaviour {

    public int sceneIndex;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BackButton()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(sceneIndex == 1 || sceneIndex == 13)
            SceneManager.LoadScene("Options");
        if (sceneIndex == 4 || sceneIndex == 7)
            SceneManager.LoadScene("MainMenu");
    }

    public void PlayButton()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        switch (sceneIndex)
        {
            case 1:
                SceneManager.LoadScene("LevelOne");
                break;
            case 4:
                SceneManager.LoadScene("LevelTwo");
                break;
            case 7:
                SceneManager.LoadScene("LevelThree");
                break;
            case 13:
                SceneManager.LoadScene("LevelFS");
                break;

        }
    }

}
