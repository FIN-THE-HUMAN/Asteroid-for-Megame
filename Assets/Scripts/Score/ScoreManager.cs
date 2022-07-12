using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private int _score;
    private int _maxScore;
    public int Score => _score;
    public int MaxScore => _maxScore;
    public List<int> _asteroidsScores;
    public int _ufoScore;
    public UnityEvent<int> ScoreIncreased;
    public UnityEvent<int> MaxScoreChanged;

    private void Start()
    {
        _maxScore = PlayerPrefs.GetInt("MaxScore");
    }

    public void IncreaseScore(int score)
    {
        _score += score;
        ScoreIncreased.Invoke(_score);
        if(_maxScore < _score)
        {
            _maxScore = _score;
            PlayerPrefs.SetInt("MaxScore", _maxScore);
            PlayerPrefs.Save();
            MaxScoreChanged.Invoke(_maxScore);
        }
    }

    public void SetScore(int score)
    {
        _score = score;
    }

    public void AddUFOScore()
    {
        IncreaseScore(_ufoScore);
    }

    public void AddAsteroidScore(Asteroid asteroid)
    {
        IncreaseScore(GetScoreFromAsteroidGeneration(asteroid.Generation));
    }

    public int GetScoreFromAsteroidGeneration(int generation)
    {
        return _asteroidsScores[generation < _asteroidsScores.Count ? generation : _asteroidsScores.Count - 1];
    }
}
