using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private int rand;
    [SerializeField] private Text[] txts;
    [SerializeField] private Image bg;
    [SerializeField] private Sprite white, black;

    private void Start()
    {
        rand = Random.Range(0, 2);
        if (rand == 0) Invert();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Erase()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public void Invert()
    {
        if(bg.sprite == white) bg.sprite = black;
        else if(bg.sprite == black) bg.sprite = white;
            foreach (Text txt in txts)
            {
                if (txt.color == Color.black) txt.color = Color.white;
                else if (txt.color == Color.white) txt.color = Color.black;
            }
    }

    public void ChangeScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
