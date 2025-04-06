using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    private GameManager G;

    private void Start()
    {
        G = GameManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            collision.GetComponent<PlayerController>().Reset();
        }
    }
}
