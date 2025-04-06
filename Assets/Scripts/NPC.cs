using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [SerializeField] private bool oneShot;
    [TextArea(4, 100)] [SerializeField] private string dialog;
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
            if (reload <= 0 && (!check || !oneShot))
            {
                G.mainText.GetComponent<Text>().text = dialog;
                check = true;
                reload = reloadTime;
                G.mainText.GetComponent<Animator>().SetTrigger("ShowText");
            }
        }
    }

    private void Update()
    {
        if(reload > 0)
        {
            reload -= Time.deltaTime;
        }
    }
}
