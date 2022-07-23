using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class ParticleEffect : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particles;

    public void PlayAtPosition(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
        StartCoroutine(PlayThenDisable());
    }

    private IEnumerator PlayThenDisable()
    {
        particles.Play();
        while (particles.isPlaying)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }

}
