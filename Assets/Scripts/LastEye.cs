using UnityEngine;
using UnityEngine.UI;

public class LastEye : MonoBehaviour
{
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
            G.cutText.text = dialog;
            G.StartEnd();
        }
    }
}
