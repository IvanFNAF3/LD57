using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CusceneScript : MonoBehaviour
{
    [SerializeField] private Text cutText;

    public void ChangeText()
    {
        cutText.text = "Thanks for playing!";
    }

    public void EndGame()
    {
        PlayerPrefs.DeleteKey("checkpointX");
        PlayerPrefs.DeleteKey("checkpointY");
        SceneManager.LoadScene(0);
    }
}
