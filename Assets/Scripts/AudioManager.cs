using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private AudioClip[] audioClips;

    void Start()
    {
        audioClips = Resources.LoadAll<AudioClip>("Audio");
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            int index;

            do
            {
                index = Random.Range(0, audioClips.Length);
            } while (audioClips[index] == audioSource.clip);

            audioSource.clip = audioClips[index];
            audioSource.Play();
        }

        if (Time.timeScale < 1 && audioSource.pitch > 0)
        {
            audioSource.pitch -= 0.01f;
        }
    }
}