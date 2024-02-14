using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesPool : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab; // The pipe prefab
    [SerializeField] private int poolSize = 5; // The pool size of the pipes
    private GameObject[] pipes; // An array of pipes

    [SerializeField] private float spawnXPosition = 8f; // The X position of the pipe
    [SerializeField] private float pipeMin = -1f; // The minimum Y position of the pipe
    [SerializeField] private float pipeMax = 3.5f; // The maximum Y position of the pipe

    private int pipeCount = 0; // The count of the pipes
    [SerializeField] private float spawnTimer = 2f; // The spawn timer of the pipes
    private float timeElapsed = 0; // The time elapsed

    void Start()
    {
        pipes = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++) // Create a pool of pipes
        {
            pipes[i] = Instantiate(pipePrefab);
            pipes[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime; // Increase the time elapsed by the time that has passed
        if (timeElapsed > spawnTimer && !GameManager.Instance.isGameOver) // If the time elapsed is greater than the spawn timer and the game is not over, spawn a pipe
        {
            timeElapsed = 0;
            SpawnPipe();
        }
    }

    private void SpawnPipe()
    {
        float spawnYPosition = Random.Range(pipeMin, pipeMax); // Randomly generate the Y position of the pipe
        Vector2 spawnPosition = new Vector2(spawnXPosition, spawnYPosition); // Set the position of the pipe
        pipes[pipeCount].transform.position = spawnPosition; 

        if (!pipes[pipeCount].activeInHierarchy) // If the pipe is not active, set it to active
        {
            pipes[pipeCount].SetActive(true);
        }
        pipeCount++; // Increase the pipe count
        if (pipeCount >= poolSize) // If the pipe count is equal to the pool size, reset the pipe count to 0
        {
            pipeCount = 0;
        }
    }
}
