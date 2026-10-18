using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region Functions

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


    public void LoadNextLevel()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }


    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    #endregion
}
