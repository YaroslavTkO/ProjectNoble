using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAndFade : MonoBehaviour
{
    public float fallSpeed = 4f; // Ўвидк≥сть пад≥нн€ об'Їкта
    public float fadeSpeed = 4f; // Ўвидк≥сть зм≥ни alpha
    private Renderer objRenderer;
    private Color originalColor;

    void Start()
    {
        // ќтримуЇмо Renderer об'Їкта дл€ зм≥ни alpha
        objRenderer = GetComponent<Renderer>();
        originalColor = objRenderer.material.color;
    }

    // ‘ункц≥€ дл€ запуску Coroutine, що опускаЇ об'Їкт ≥ зменшуЇ alpha
    public void StartFalling()
    {
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(FallAndFadeCoroutine());
    }

    // Coroutine дл€ пад≥нн€ ≥ зм≥ни alpha
    private IEnumerator FallAndFadeCoroutine()
    {
        float startY = transform.position.y; 
        float startAlpha = originalColor.a;
        float targetY = startY - 10f; 
        float targetAlpha = 0f; 

        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            float t = elapsedTime / 1f;

            // –ух по Y
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(startY, targetY, t), transform.position.z);

            // «м≥на alpha
            Color currentColor = objRenderer.material.color;
            currentColor.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            objRenderer.material.color = currentColor;

            elapsedTime += Time.deltaTime * fallSpeed; 
            yield return null; 
        }

        transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
        Color finalColor = objRenderer.material.color;
        finalColor.a = targetAlpha;
        objRenderer.material.color = finalColor;
    }
}
