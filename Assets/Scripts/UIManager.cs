using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textLevel;
    [SerializeField] private GameObject _finishWindow;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _buttonSettings;

    private void Start()
    {
        EventBus.LevelFinished += OnLevelFinish;

        _textLevel.text = SceneManager.GetActiveScene().name;

        _settingsMenu.SetActive(false);
        _finishWindow.SetActive(false);
    }

    private void OnLevelFinish()
    {
        ShowFinishWindow();
    }

    public void ShowFinishWindow()
    {
        _finishWindow.SetActive(true);
    }

    public void SettingsOpen()
    {
        _settingsMenu.SetActive(true);
        _buttonSettings.SetActive(false);
    }

    public void SettingsClose()
    {
        _settingsMenu.SetActive(false);
        _buttonSettings.SetActive(true);
    }

    private void OnDestroy()
    {
        EventBus.LevelFinished -= OnLevelFinish;
    }
}
