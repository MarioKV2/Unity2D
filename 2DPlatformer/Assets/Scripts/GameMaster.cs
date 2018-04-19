using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;
    public CountdownUI timer;

    void Awake()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    public Transform playerPrefab;
    public Transform enemyPrefab;

    public Transform spawnPoint;
    public Transform[] enemySpawnPoints;

    public float spawnDelay = 2;

    public Transform spawnPrefab;
    public Transform enemySpawnPrefab;


    public IEnumerator RespawnPlayer() {
        GetComponent<AudioSource>().Play();
        timer.pause = true;
        yield return new WaitForSeconds(spawnDelay);

        timer.timeLeft = 0;
        timer.pause = false;
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Transform clone = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation) as Transform;
        Destroy(clone.gameObject, 3f);

    }

    public IEnumerator RespawnEnemy()
    {
        yield return new WaitForSeconds(spawnDelay);

		int random = Random.Range (0, enemySpawnPoints.Length - 1);
		Instantiate(enemyPrefab, enemySpawnPoints[random].position, enemySpawnPoints[random].rotation);
		Transform enemyClone = Instantiate(enemySpawnPrefab, enemySpawnPoints[random].position, enemySpawnPoints[random].rotation) as Transform;
        Destroy(enemyClone.gameObject, 3f);
    }

    public static void KillPlayer(Player player) {

        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());

    }

    public static void KillEnemy(Enemy enemy){
        Destroy(enemy.gameObject);
        gm.StartCoroutine(gm.RespawnEnemy());
    }
} 
