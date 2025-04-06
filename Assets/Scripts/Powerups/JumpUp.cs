using UnityEngine;

public class JumpUp : MonoBehaviour
{
    [SerializeField] private float forceDelta;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            collision.GetComponent<PlayerController>().JumpUp(forceDelta);
            Destroy(gameObject);
        }
    }
}
