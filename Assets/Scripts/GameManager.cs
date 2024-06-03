using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private TextMeshProUGUI _textLevel;
    [SerializeField] private GameObject _finishWindow;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _buttonSettings;
    [SerializeField] private CoinManager _coinManager;

    private void Start()
    {
        _textLevel.text = SceneManager.GetActiveScene().name;

        _settingsMenu.SetActive(false);
        _finishWindow.SetActive(false);
    }

    public void Play()
    {
        _startMenu.SetActive(false);
        FindObjectOfType<PlayerBehaviour>().Play();
    }

    public void ShowFinishWindow()
    {
        _finishWindow.SetActive(true);
    }

    public void NextLevel()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            _coinManager.SaveToProgress();

            Progress.Instance.PlayerInfo.Level = SceneManager.GetActiveScene().buildIndex;

            Progress.Instance.Save();
            SceneManager.LoadScene(nextIndex);
        }
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
}
