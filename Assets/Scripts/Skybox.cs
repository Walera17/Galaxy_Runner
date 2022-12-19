using UnityEngine;

public class Skybox : MonoBehaviour
{
    [SerializeField] [Range(0.5f, 3f)] private float speed=2f;
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed);
    }
}