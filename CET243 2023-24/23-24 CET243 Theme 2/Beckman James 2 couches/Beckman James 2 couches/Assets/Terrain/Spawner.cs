using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;

    [SerializeField] private GameObject[] obstacleprefabs;

    [SerializeField] private bool canSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawner2());

    }

    private IEnumerator Spawner2()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (canSpawn)
        {
            yield return wait;
            int rand = Random.Range(0, obstacleprefabs.Length);
            GameObject obstacleToSpawn = obstacleprefabs[rand];

            Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
        }

    }
}
