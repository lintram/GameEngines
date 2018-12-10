using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int coins;
    public Text coinsText;

    //GameOver
    public GameObject player;
    public GameObject GameOverUI;
    public GameObject GameWonUI;
    public bool gameOver;
    public bool gameWon;
    // Use this for initialization

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = ("Coins: " + coins);

        if (gameOver)
        {
            GameEnded();
        }

        if (gameWon)
        {
            GameWon();
        }

    }
    public void GameEnded()
    {
        Debug.Log("GameOver");
        GameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameWon()
    {
        GameWonUI.SetActive(true);
        Time.timeScale = 0;
    }
}
