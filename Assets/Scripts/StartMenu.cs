using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene(Progress.Instance.PlayerInfo.Level + 1);
    }
}
