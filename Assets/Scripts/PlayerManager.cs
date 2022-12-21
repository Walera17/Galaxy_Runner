using System;
using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float _score;
    private float _highScore;
    private GameData gameData;

    public float Score
    {
        get => _score;
        set { _score += value; print("This Game Score = " + Score); HighScore = _score; }
    }

    public float HighScore
    {
        get => _highScore;
        set
        {
            if (_highScore < value)
            {
                _highScore = value;
                gameData.SaveScore(_highScore);

                //// С помощью PlayerPrefs
                //PlayerPrefs.SetFloat("HighScore", _highScore);
                //PlayerPrefs.Save();
            }
        }
    }

    private void Start()
    {
        //Score = 10;

        gameData = new GameData();

        GameData loadedData = null;

        try
        {
            loadedData = SavingSystem.instance.LoadGame();
        }
        catch (Exception e)
        {
            print("Data does not exist!");
            print(e);
        }

        if (loadedData != null)
            gameData = loadedData;
        else
            gameData.SaveScore(0);

        HighScore = gameData.GetScore();

        print("HighScore = " + HighScore);

        //// С помощью PlayerPrefs
        //if (PlayerPrefs.HasKey("HighScore"))
        //{
        //    _highScore = PlayerPrefs.GetFloat("HighScore");
        //    print("Found " + _highScore);
        //}
        //else
        //{
        //    PlayerPrefs.SetFloat("HighScore", 0);
        //    print("Not found");
        //    _highScore = 0;
        //    PlayerPrefs.Save();
        //}
    }

    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.CompareTag("Boarder")) return;

    //    HighScore = Score;

    //    StartCoroutine(SlowTime());
    //}

    private IEnumerator SlowTime()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(0.75f);
        Time.timeScale = 0f;
    }
}