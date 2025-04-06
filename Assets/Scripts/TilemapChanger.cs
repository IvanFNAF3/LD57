using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapChanger : MonoBehaviour
{
    public void ChangeColor(Color targetColor)
    {
        StartCoroutine(LerpColor(targetColor));
    }
    private IEnumerator LerpColor(Color targetColor)
    {
        Tilemap sr = GetComponent<Tilemap>();
        Color startColor = sr.color;

        float duration = 1.0f; //1 sec
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            sr.color = Color.Lerp(startColor, targetColor, elapsedTime / duration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        sr.color = targetColor;
    }
}
