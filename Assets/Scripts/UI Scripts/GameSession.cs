using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public int score = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        SingletonSetUp();
    }

    void SingletonSetUp()
    {
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddToScore(int amount)
    {
        score += amount;
    }

    public void ResetGameScore()
    {
        Destroy(gameObject);
    }
}
