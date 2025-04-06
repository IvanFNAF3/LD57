using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private float offset;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            PlayerPrefs.SetFloat("checkpointX", transform.position.x);
            PlayerPrefs.SetFloat("checkpointY", transform.position.y + offset);
            Debug.Log(PlayerPrefs.GetFloat("checkpointX") + " " + PlayerPrefs.GetFloat("checkpointY"));
        }
    }
}
