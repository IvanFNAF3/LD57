using UnityEngine;
using UnityEngine.UI;

public class PathItem : MonoBehaviour
{
    [SerializeField] private bool red;
    private GameManager G;
    [TextArea(4, 100)]
    [SerializeField] private string dialog;
    private void Start()
    {
        G = GameManager.instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            if (red) G.mainText.GetComponent<Text>().color = Color.red;
            G.mainText.GetComponent<Text>().text = dialog;
            G.mainText.GetComponent<Animator>().SetTrigger("ShowText");
            Destroy(gameObject);
            PlayerPrefs.SetInt("flower", 1337);
            G.UpdateObjs();
        }
    }
}
