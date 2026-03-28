using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Material[] gameColors;
    public Transform player;

    public float spawnDistance = 50f;
    public float spawnInterval = 1.5f;
    private float timer;

    private void Update()
    {

        if (GameManager.Instance.IsGameOver) return;

   
        if (!GameManager.Instance.isGameStarted) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnNewObstacle();
            timer = 0f;
        }
    }

    private void SpawnNewObstacle()
    {
        Vector3 spawnPos = new Vector3(0, 1, player.position.z + spawnDistance);
        GameObject newObs = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

        
        newObs.GetComponent<Obstacle>().Setup(gameColors, player);
    }
}