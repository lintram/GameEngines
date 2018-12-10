using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Vector2 direction;

    public float speed = 3;
    public float jumpPower = 10;
    public Rigidbody2D rigidbody;
    private Animator animator;
    public GameController gameController;
    public bool isOnGround = false;
    public bool isRunning; 


	// Use this for initialization
	void Start () {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        GetInput();
		
	}
    public void GetInput()
    {
        direction = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.D))
        {
            direction = new Vector2(1, 0);
            transform.localScale = new Vector3(1, 1, 1);
            isRunning = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction = new Vector2(-1, 0);
            transform.localScale = new Vector3(-1, 1, 1);
            isRunning = true;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (isOnGround)
            {
                rigidbody.AddForce(new Vector2(0, 10) * jumpPower);
            }   
        }
        transform.Translate(direction * speed * Time.deltaTime);
        Animate();
        isRunning = false;


    }

    public void Animate()
    {
        animator.SetBool("running", isRunning);
        animator.SetBool("ground", isOnGround);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag ("Collectible"))
        {
            gameController.coins = gameController.coins + 10;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("GameOver"))
        {
            gameController.gameOver = true;
        }

        if (collision.CompareTag("Goal"))
        {
            Debug.Log("You win!");
            gameController.gameWon = true;
        }
    }

}
