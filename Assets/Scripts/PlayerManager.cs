using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float _score;
    private float _highScore;

    public float Score
    {
        get => _score;
        set { _score += value; print(Score); HighScore = _score; }
    }

    public float HighScore
    {
        get => _highScore;
        set
        {
            if (_highScore < value)
            {
                _highScore = value;
                PlayerPrefs.SetFloat("HighScore", _highScore);
                PlayerPrefs.Save();
            }
        }
    }

    private void Start()
    {
        //Score = 10;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            _highScore = PlayerPrefs.GetFloat("HighScore");
            print("Found " + _highScore);
        }
        else
        {
            PlayerPrefs.SetFloat("HighScore", 0);
            print("Not found");
            _highScore = 0;
            PlayerPrefs.Save();
        }
    }
}