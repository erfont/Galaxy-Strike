using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Scoreboard : MonoBehaviour
{
    private int score;

    public void IncreaseScore(int amount)
    {
        score += amount; 
        Debug.Log(score);
    }

}
