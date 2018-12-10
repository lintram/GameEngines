using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    public GameObject EnemyType; //put prefab of enemy in here

    public float Level = 1f;

    private Vector2 spawnPosition;


    // Use this for initialization
    void Start () {

      StartEnemySpawn();
    }
	
	// Update is called once per frame
	void Update () {

    }

    void SpawnEnemy()
    {
        spawnPosition.x = transform.position.x; //transform.position is the position of this gameobject
        spawnPosition.y = transform.position.y;

        GameObject newEnemy = (GameObject)Instantiate(EnemyType); // creates new enemy
        newEnemy.transform.position = new Vector2(spawnPosition.x, spawnPosition.y);

        NextEnemySpawn();
    
    }

    void NextEnemySpawn()
    {
        float spawnInNSeconds;
            spawnInNSeconds = Random.Range(1f , 5f); //spawn after random time between 1 and 5 sec
            Invoke("SpawnEnemy", spawnInNSeconds); //start the method after rand time

    }

    public void StartEnemySpawn()
    {
        Invoke("SpawnEnemy", 0.5f);
    }

    public void StopEnemySpawn()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("NextEnemySpawn");
    }

}
