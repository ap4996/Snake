using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Challenge()
    {
        SceneManager.LoadScene("Instruction1");
    }

    public void Freestyle()
    {
        SceneManager.LoadScene("IF");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
