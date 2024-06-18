using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private CoinManager _coinManager;

    public void Play()
    {
        _startMenu.SetActive(false);
        EventBus.OnLevelStarted();
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
}
