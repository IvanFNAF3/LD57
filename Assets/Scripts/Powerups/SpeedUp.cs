using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    [SerializeField] private float speedDelta;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            collision.GetComponent<PlayerController>().SpeedUp(speedDelta);
            Destroy(gameObject);
        }
    }
}
