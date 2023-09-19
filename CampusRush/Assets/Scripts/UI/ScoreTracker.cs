//Author: Rhiannon Strickland
//Date: April 7, 2023
//This script controls the score tracking. Just call the score tracker and it will update the rest!
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    public int score = 0;

    private void Awake()
    {
        text.text = score.ToString();
    }

    public void AddPoints(int points)
    {
        score += points;
        text.text = score.ToString();
    }
    public void ResetPoints()
    {
        score = 0;
        text.text = score.ToString();
    }
}
