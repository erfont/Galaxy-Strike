using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    private int score;

    [SerializeField] TMP_Text scoreBoardText;

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreBoardText.text = score.ToString();
    }

}
