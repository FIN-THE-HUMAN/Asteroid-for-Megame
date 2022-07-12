using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatsPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _livesText;

    public void SetScore(int score)
    {
        _scoreText.text = score.ToString();
    }

    public void SetLives(int lives)
    {
        _livesText.text = lives.ToString();
    }
}
