using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public float totalXixi = 10;
    
    public float xixiToIncrease = 1;
    public float timeToXixi= 4;

    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;

    public GameController gameController;

    private Vector3 startPosition;
    private float currentTimeToXixi = 0;
    private float currentXixi = 0;

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	public void Move () {

        CharacterController controller = GetComponent<CharacterController>();
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);

        if(transform.position.y <= -5)
        {
            
            gameController.SwitchState(stateMachine.LOSE);
        }

        

    }

    public float getCurrentXixi()
    {
        return currentXixi;
    }

    public void IncreaseXixi()
    {
        currentTimeToXixi += Time.deltaTime;

        if(currentTimeToXixi > timeToXixi)
        {
            currentTimeToXixi = 0;
            currentXixi += xixiToIncrease;
        }

        if (currentXixi > totalXixi)
        {
            gameController.SwitchState(stateMachine.LOSE);
        }

    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Enemy"){
            gameController.SwitchState(stateMachine.LOSE);
        }

        if (hit.gameObject.tag == "CheckPoint")
        {
            currentXixi = 0;
            gameController.SwitchState(stateMachine.WIN);

        }
    }

    public void ResetPosittion()
    {
        transform.position = startPosition;
    }
}
