using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        BasicInputs();

    }

    void BasicInputs()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel("Loader");
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

    }
}
