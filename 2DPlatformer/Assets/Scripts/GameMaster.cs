using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;

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
    public Transform enemySpawnPoint;

    public float spawnDelay = 2;

    public Transform spawnPrefab;
    public Transform enemySpawnPrefab;


    public IEnumerator RespawnPlayer() {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Transform clone = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation) as Transform;
        Destroy(clone.gameObject, 3f);

    }

    public IEnumerator RespawnEnemy()
    {
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(enemyPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
        Transform enemyClone = Instantiate(enemySpawnPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation) as Transform;
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
