using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour {

    public TextMesh score;
    public PlayerBehaviour player;
    public Transform barXixi;

    private Vector3 newSize;
    private Vector3 sizeBarXixi;

	// Use this for initialization
	void Start () {
        sizeBarXixi = barXixi.transform.localScale;
        newSize = sizeBarXixi;
    }
	
	// Update is called once per frame
	void Update () {

        newSize.x = sizeBarXixi.x * player.getCurrentXixi() / player.totalXixi;
        barXixi.transform.localScale = newSize;
		
	}

    public void AddScore(int newScore)
    {
        score.text = "Score:" + newScore;
    }
}
