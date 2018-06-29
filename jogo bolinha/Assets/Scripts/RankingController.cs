using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingController : MonoBehaviour {

    public TextMesh scoreDisplay;

	// Use this for initialization
	void Start () {

        scoreDisplay.text = "";

        int[] tempRanking = ApplicationController.GetRanking();

        for(int i = ApplicationController.numberPositionRanking - 1; i>=0; i--)
        {
            scoreDisplay.text += tempRanking[i].ToString("D4");
            scoreDisplay.text += "\n";
        }
	}
	
	// Update is called once per frame
	void Update () {
        BasicInputs();

    }

    void BasicInputs(){
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel("GamePlay");
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

    }
}
