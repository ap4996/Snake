using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueScript : MonoBehaviour {

    private readonly float delay = 2f;
    private float timeElapsed;
    public int sceneIndex;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= delay)
        {
            switch (sceneIndex)
            {
                case 2:
                    SceneManager.LoadScene("GameScene");
                    break;
                case 5:
                    SceneManager.LoadScene("GameScene2");
                    break;
                case 8:
                    SceneManager.LoadScene("GameScene3");
                    break;
                case 14:
                    SceneManager.LoadScene("GameFreestyle");
                    break;
            } 
        }
	}
}
