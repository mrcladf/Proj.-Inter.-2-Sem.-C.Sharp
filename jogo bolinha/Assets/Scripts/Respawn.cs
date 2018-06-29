using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    private Vector3 posicaoInicial =  new Vector3();

    // Use this for initialization
    void Start () {
        posicaoInicial = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -100)
        {
            transform.position = posicaoInicial;
        }
    }
}
