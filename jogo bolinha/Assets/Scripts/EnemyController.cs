using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float radiusMin = 30;
    public float radiusMax = 50;

    public int totalEnemysInGame;
    public float timeToRespawn;

    public float difficultFactor = 1;
    public float difficultAdd = 0.01f;

    public EnemyBehaviour enemy;

    public GameController gameController;

    private float currentTime = 0;

    private int currentEnemys = 0;

	// Use this for initialization
	void Start () {
		
	}

    public void DecreaseEnemy()
    {
        if (currentEnemys > 0)
        {
            currentEnemys--;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (currentEnemys < totalEnemysInGame)
        {
            if (currentTime > timeToRespawn && gameController.GetCurrentState() == stateMachine.PLAY)
            {
                CreateEnemy();
                currentTime = 0;
            }
            else
            {
                currentTime += Time.deltaTime;
            }
        }
	}
    void CreateEnemy()
    {
        GameObject tempEnemy = Instantiate(enemy.gameObject) as GameObject;

        tempEnemy.transform.parent = transform;

        Vector3 newPosition = gameController.player.transform.position;

        newPosition.x = newPosition.x + (Random.Range(Random.Range(-radiusMin, radiusMin), Random.Range(-radiusMax, radiusMax)));
        newPosition.z = newPosition.z + (Random.Range(Random.Range(-radiusMin, radiusMin), Random.Range(-radiusMax, radiusMax)));

        tempEnemy.transform.position = newPosition;

        tempEnemy.GetComponent<EnemyBehaviour>().enemyController = this;

        currentEnemys++;
        
    }

    public void AddDificult()
    {
        difficultFactor += difficultAdd;
    }
}
