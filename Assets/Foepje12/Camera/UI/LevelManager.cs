using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region Functions

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    #endregion
}
