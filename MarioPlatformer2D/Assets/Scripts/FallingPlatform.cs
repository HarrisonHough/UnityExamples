﻿using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField]
    private float fallDelay = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Contains("Player"))
        {

        }
    }

    private IEnumerator FallCoroutine()
    {
        float timeToFall = Time.time + fallDelay;
        while (Time.time < timeToFall)
        {
            yield return null;
        }

        //apply gravity

        //then destroy after time

    }
}
