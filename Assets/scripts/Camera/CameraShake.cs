using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator IShake(float duration, float magnitude)
    {
        /*you can set the originalPos to transform.localPosition of the camera in in that instance. */
        Vector3 originalPos = transform.localPosition;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float x0ffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float y0ffset = Random.Range(-0.5f, 0.5f) * magnitude;
            transform.localPosition = new Vector3(x0ffset, y0ffset, originalPos.z);
            elapsedTime += Time.deltaTime;
            //wait one frame
            yield return null;
        }
        transform.localPosition = originalPos;
    }

    public void Shake(float iduration, float imagnitude) { StartCoroutine(IShake(iduration,imagnitude));  }
}

