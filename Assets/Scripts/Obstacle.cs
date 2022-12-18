using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject[] tiles;

    private readonly List<int> obstacles = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };

    private void Start()
    {
        RandomizeObstacle();
    }

    void RandomizeObstacle()
    {
        foreach (GameObject tile in tiles)
            tile.SetActive(true);

        int number = Random.Range(1, 15);

        List<int> temp = new List<int>(obstacles);

        int index;

        for (int i = 0; i < number; i++)
        {
            index = Random.Range(0, temp.Count);

            tiles[temp[index]].SetActive(false);

            temp.Remove(index);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2 + 60 * 4);

        RandomizeObstacle();
    }
}