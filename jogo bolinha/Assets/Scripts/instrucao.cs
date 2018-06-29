using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instrucao : MonoBehaviour {
    private float tela = 4;
    private float tempoEmTela = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        tempoEmTela += Time.deltaTime;
        if(tempoEmTela > tela)
        {
            Destroy(gameObject);
        }
    }
}
