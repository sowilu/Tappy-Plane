using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void ReloadLevel()
    {
        var levelName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(levelName);
    }
}
