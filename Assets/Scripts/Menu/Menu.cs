using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _loseMenu;
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _scoreObject;
    [SerializeField] private TMP_Text _maxScore;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Animator _pauseImage;
    [SerializeField] private bool _isPaused;

    [SerializeField] private UnityEvent _gamePaused;
    [SerializeField] private UnityEvent _gameContinued;

    void Start()
    {
        Time.timeScale = 0;
        ShowMenu(_startMenu);
        _scoreObject.SetActive(true);
        _maxScore.text = PlayerPrefs.GetInt("MaxScore").ToString();
    }

    public bool IsPaused => _isPaused;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                ContinueGame();
                _isPaused = false;
                _gameContinued.Invoke();
                _pauseImage.SetTrigger("TrContinued");
            }
            else
            {
                PauseGame();
                _isPaused = true;
                _gamePaused.Invoke();
                _pauseImage.SetTrigger("TrPaused");
            }
        }
    }

    public void ShowScore()
    {
        _scoreObject.SetActive(true);
    }

    public void ShowMenu(GameObject menu)
    {
        menu.SetActive(true);
        _isPaused = true;
        _gamePaused.Invoke();
    }

    public void ShowLoseMenu()
    {
        _loseMenu.SetActive(true);
        _isPaused = true;
        _gamePaused.Invoke();
        ShowScore();
    }

    public void StartGame()
    {
        _startMenu.SetActive(false);
        _scoreObject.SetActive(false);
        _isPaused = false;
        _gameContinued.Invoke();
        Time.timeScale = 1;
    }

    public void ContinueGame()
    {
        _pauseMenu.SetActive(false);
        _scoreObject.SetActive(false);
        Time.timeScale = 1;
        _isPaused = false;
        _gameContinued.Invoke();
    }

    public void PauseGame()
    {
        _pauseMenu.SetActive(true);
        ShowScore();
        Time.timeScale = 0;
        _isPaused = true;
        _gamePaused.Invoke();
    }

    public void SetMaxScoreText(int maxScore)
    {
        _maxScore.text = maxScore.ToString();
    }

    public void SetScoreText(int score)
    {
        _score.text = score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
