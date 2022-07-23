using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    private float shakeDuration = 0.2f;
    [SerializeField]
    private float shakeMagnitude = 0.4f;

    public void StartShakeEffect()
    {
        StartCoroutine(ShakeRoutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartShakeEffect();
        }
    }

    private IEnumerator ShakeRoutine()
    {
        Vector3 startPosition = transform.localPosition;

        var elapsedTime = 0.0f;

        while (elapsedTime < shakeDuration)
        {
            var x = Random.Range(-1f, 1f) * shakeMagnitude;
            var y = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.localPosition = new Vector3(x, y, startPosition.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = startPosition;

    }
}
