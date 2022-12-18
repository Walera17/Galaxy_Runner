using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    private GameObject obstacle;
    private Transform playerTransform;
    private int numberOfObstacle = 4;

    private void Start()
    {
        obstacle = Resources.Load<GameObject>("ObstacleObject");
        playerTransform = GameObject.FindWithTag("Player").transform;

        for (int i = 0; i < numberOfObstacle; i++)
        {
            Instantiate(obstacle, playerTransform.position + Vector3.forward * (60 + i * 60), Quaternion.Euler(0, 90, 0), transform);
        }
    }
}