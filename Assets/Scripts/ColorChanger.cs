using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour
{
    public void ChangeColor(Color targetColor)
    {
        StartCoroutine(LerpColor(targetColor));
    }
    private IEnumerator LerpColor(Color targetColor)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
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