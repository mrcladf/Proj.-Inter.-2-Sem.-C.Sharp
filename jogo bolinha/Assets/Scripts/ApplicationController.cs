using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationController : MonoBehaviour {

    public static int numberPositionRanking = 5;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);

        Application.LoadLevel("Gameplay");
	}
	
	public static void AddToRanking(int score)
    {
        int[] tempRanking = GetRanking();

        int positionScore = -1;

        for(int i=0; i<numberPositionRanking; i++)
        {
            if(score> tempRanking[i])
            {
                positionScore = i;
            }
        }
        if(positionScore > -1)
        {
            int oldScore = tempRanking[positionScore];

            PlayerPrefs.SetInt("Position" + positionScore, score);

            AddToRanking(oldScore);
        }
    }

    public static int[] GetRanking()
    {
        int[] tempRanking = new int[numberPositionRanking];

        for(int i =0; i < numberPositionRanking; i++)
        {
            if (PlayerPrefs.HasKey("Position" + i))
            {
                tempRanking[i] = PlayerPrefs.GetInt("Position" + i);
            }
        }

        return tempRanking;
    } 
}
