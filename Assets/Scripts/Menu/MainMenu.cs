using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameLoadScriptableObject _gameLoadScriptableObject;
    [SerializeField] private RocketControlsScriptableObject _rocketControlsScriptableObject;
    [SerializeField] private Button _continueButton;
    public UnityEvent<RocketMovingControls> ControlsSettingsChanged;

    private void Start()
    {
        ControlsSettingsChanged.Invoke(_rocketControlsScriptableObject.Controls);
        _continueButton.interactable = _gameLoadScriptableObject.GameWasSaved;
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        _gameLoadScriptableObject.LoadGame = false;
        SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
        _gameLoadScriptableObject.LoadGame = true;
        SceneManager.LoadScene(1);
    }

    public void ChangeControlsSettings()
    {
        _rocketControlsScriptableObject.Controls = _rocketControlsScriptableObject.Controls == RocketMovingControls.Keyboard ? RocketMovingControls.MouseAndKeyboard : RocketMovingControls.Keyboard;
        ControlsSettingsChanged.Invoke(_rocketControlsScriptableObject.Controls);
    }

}
