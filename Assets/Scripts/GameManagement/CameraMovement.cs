using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float duration = 0.5f;
    private Coroutine moveCoroutine;




    public void MoveVertical(float height)
    {
        if (transform.position.y >= height)
        {
            return;
        }
        var targetPosition = new Vector3(transform.position.x, height, transform.position.z);
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        moveCoroutine = StartCoroutine(MoveCamera(targetPosition, duration));
    }

    private IEnumerator MoveCamera(Vector3 targetPosition, float duration)
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        moveCoroutine = null;
    }
}

