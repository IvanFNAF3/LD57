using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Eye : MonoBehaviour
{
    [SerializeField] private bool redEye;
    [SerializeField] private bool dontDestroy;
    private GameManager G;
    [TextArea(4, 100)]
    [SerializeField] private string dialog;
    private void Start()
    {
        G = GameManager.instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            if (redEye) G.mainText.GetComponent<Text>().color = Color.red;
            G.mainText.GetComponent<Text>().text = dialog;
            G.mainText.GetComponent<Animator>().SetTrigger("ShowText");
            if(!dontDestroy)
            Destroy(gameObject);
            G.UpdateObjs();
        }
    }
}
