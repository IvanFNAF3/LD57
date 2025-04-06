using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Erase()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
}
