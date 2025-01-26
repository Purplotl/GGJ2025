using Enemy.behaviour;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    [SerializeField] private float spawnTime;
    [SerializeField]private GameObject[] enemies;
    [SerializeField] GameObject[] spawnPoints;

    private float spawnTimer;
    private float xPos;
    private float yPos;

    private void Start()
    {
        spawnTimer = Random.Range(spawnTime - 2f, spawnTime + 2f);
    }

    private void Update()
    {
        //if (win_controller.win || win_controller.lose) return;

        if (spawnTimer > 0)
        {
            spawnTimer -= Time.fixedDeltaTime;
        }
        else
        {
            SpawnEnemy();
            spawnTimer = Random.Range(spawnTime - 2f, spawnTime + 2f);
        }
    }

    private void SpawnEnemy()
    {
        int enemy = Random.Range(0,4);
        GameObject clone = Instantiate(enemies[enemy]);

        Vector3 spawnPointA = spawnPoints[0].transform.position;
        Vector3 spawnPointB = spawnPoints[1].transform.position;

        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0:
                yPos = spawnPointA.y;
                xPos = (Random.Range(spawnPointA.x, spawnPointB.x));
                break;

            case 1:
                xPos = spawnPointA.x;
                yPos = (Random.Range(spawnPointA.y, spawnPointB.y));
                break;

            case 2:
                yPos = spawnPointB.y;
                xPos = (Random.Range(spawnPointA.x, spawnPointB.x));
                break;

            case 3:
                xPos = spawnPointB.x;
                yPos = (Random.Range(spawnPointA.y, spawnPointB.y));
                break;
        }

        clone.transform.position = new Vector3(xPos, yPos);

        clone.GetComponent<projectile_collision>().enabled = true;
        clone.GetComponent<enemy_health>().enabled = true;
        clone.GetComponent<enemy_movement>().enabled = true;
    }
}
