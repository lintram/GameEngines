using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private PlayerMovement playerMovement;

	// Use this for initialization
	void Start () {
        playerMovement = gameObject.GetComponentInParent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            playerMovement.isOnGround = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            playerMovement.isOnGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        playerMovement.isOnGround = false;
    }
    

}
