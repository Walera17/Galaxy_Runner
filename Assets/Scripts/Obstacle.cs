using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject[] tilesGameObjects;
    [SerializeField] private Tile[] tiles;

    private readonly List<int> obstacles = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
    private readonly List<int> constantlyActivates = new List<int>() { 4, 9, 14, 19, 24 };

    private static Material[] _materials;
    private static PlayerManager _playerManager;

    private void Start()
    {
        if (_materials == null)
        {
            _materials = Resources.LoadAll<Material>("Materials");
            //Debug.Log("Load materials");
        }

        if (_playerManager == null)
            _playerManager = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();

        RandomizeObstacle();
    }

    void RandomizeObstacle()
    {
        int number = Random.Range(1, 15);

        List<int> temp = new List<int>(obstacles);

        int index;

        for (int i = 0; i < number; i++)
        {
            do
            {
                index = Random.Range(0, temp.Count);
            } while (constantlyActivates.Contains(temp[index]));

            tilesGameObjects[temp[index]].SetActive(false);

            temp.RemoveAt(index);
        }

        foreach (int tileNumber in temp)
        {
            tilesGameObjects[tileNumber].SetActive(true);
            tiles[tileNumber].ResetTile(_materials[Random.Range(0, _materials.Length)]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 15 + 60 * 4);

        RandomizeObstacle();

        _playerManager.Score = 10;
    }

    private void OnDestroy()
    {
        if (_playerManager != default)
        {
            _playerManager = null;
            //print("Destroy playerManager");
        }

        if (_materials != default)
        {
            _materials = null;
            //print("Destroy materials");
        }
    }
}