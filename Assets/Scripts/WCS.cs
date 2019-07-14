using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WCS : MonoBehaviour {

    //private readonly float delay = 2f;
    //private float timeElapsed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*timeElapsed += Time.deltaTime;
        if (timeElapsed >= delay)
        {
            SceneManager.LoadScene(0);
        }*/
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
