using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAndFade : MonoBehaviour
{
    public float fallSpeed = 4f; // �������� ������ ��'����
    public float fadeSpeed = 4f; // �������� ���� alpha
    private Renderer objRenderer;
    private Color originalColor;

    void Start()
    {
        // �������� Renderer ��'���� ��� ���� alpha
        objRenderer = GetComponent<Renderer>();
        originalColor = objRenderer.material.color;
    }

    // ������� ��� ������� Coroutine, �� ������ ��'��� � ������ alpha
    public void StartFalling()
    {
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(FallAndFadeCoroutine());
    }

    // Coroutine ��� ������ � ���� alpha
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

            // ��� �� Y
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(startY, targetY, t), transform.position.z);

            // ���� alpha
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
