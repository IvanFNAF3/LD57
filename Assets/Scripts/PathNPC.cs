using UnityEngine;
using UnityEngine.UI;

public class PathNPC : MonoBehaviour
{
    [TextArea(4, 100)][SerializeField] private string firstDialog;
    [TextArea(4, 100)][SerializeField] private string lastDialog;
    private bool check = false;
    private float reload = 0f;
    private float reloadTime = 4f;
    private GameManager G;

    private void Start()
    {
        G = GameManager.instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            if (PlayerPrefs.HasKey("flower"))
            {
                if (reload <= 0)
                {
                    G.mainText.GetComponent<Text>().text = lastDialog;
                    G.hasQuestItem = false;
                    check = true;
                    reload = reloadTime;
                    G.mainText.GetComponent<Animator>().SetTrigger("ShowText");
                    Destroy(gameObject);
                }
            }
            else
            {
                if (reload <= 0)
                {
                    G.mainText.GetComponent<Text>().text = firstDialog;
                    check = true;
                    reload = reloadTime;
                    G.mainText.GetComponent<Animator>().SetTrigger("ShowText");
                }
            }
        }
    }

    private void Update()
    {
        if (reload > 0)
        {
            reload -= Time.deltaTime;
        }
    }
}
