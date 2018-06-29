using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour {

    public Transform checkPointPrefab;
    public float radiusSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Transform SpawnCheckPoint()
    {
        Transform tempCheckPoint = Instantiate(checkPointPrefab) as Transform;
        SpawnInNewPosition(tempCheckPoint);
        return tempCheckPoint;
    }
    public void SpawnInNewPosition(Transform checkPoint)
    {
        Vector3 newPosition = transform.position;
        newPosition.x += Random.Range(-radiusSpawn, radiusSpawn);
        newPosition.z += Random.Range(-radiusSpawn, radiusSpawn);

        checkPoint.transform.position = newPosition;
    }
}
