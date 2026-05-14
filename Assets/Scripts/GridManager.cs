using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int gridSize = 12;
    public int enemyCount = 5;

    public int width = 10;
    public int height = 10;
    public float cellSize = 1f;

    public GameObject cellPrefab;

    private List<Vector2> usedPositions = new List<Vector2>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateGrid();
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2 worldPosition = new Vector2(x * cellSize, y * cellSize);

                if (cellPrefab != null)
                {
                    Instantiate(cellPrefab, worldPosition, Quaternion.identity, transform);
                }
            }
        }
    }

    Vector2 GetRandomGridPositon()
    {
        int x = Random.Range(0, gridSize);
        int y = Random.Range(0, gridSize);

        return new Vector2(x, y);
    }

    bool isPositionAvailable(Vector2 position)
    {
        return !usedPositions.Contains(position);
    }

    void SpawnEnemies()
    {
        int spawned = 0;

        while (spawned < enemyCount)
        {
            Vector2 randomPos = GetRandomGridPositon();

            if (isPositionAvailable(randomPos))
            {
                Instantiate(enemyPrefab, randomPos, Quaternion.identity);
                usedPositions.Add(randomPos);
                spawned++;
            }
        }
    }
}
