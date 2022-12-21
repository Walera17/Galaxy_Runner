using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        pos.z = player.position.z;
        transform.position = pos;
    }
}