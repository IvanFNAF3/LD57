using UnityEngine;
using UnityEngine.SceneManagement;

public class Deadline : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            collision.transform.position = new Vector3(PlayerPrefs.GetFloat("checkpointX"), PlayerPrefs.GetFloat("checkpointY"), 0); ;
        }
    }
}
