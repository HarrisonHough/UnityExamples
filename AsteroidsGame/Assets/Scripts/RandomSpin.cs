using System.Collections;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2017
* VERSION: 1.0
* SCRIPT: Random Spin Class
*/

public class RandomSpin : MonoBehaviour
{

    [SerializeField]
    private Transform rotateTarget;
    [SerializeField]
    private float rotationSpeed = 3;

    private bool rotate;
    
    private void Start()
    {
        if (rotateTarget == null)
            rotateTarget = transform.GetChild(0).transform;

        StartSpin();

    }

    /// <summary>
    /// 
    /// </summary>
    public void StartSpin()
    {
        if (rotate) return;

        rotate = true;
        StartCoroutine(Spin());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private Quaternion RandomRotation()
    {
        float xRot = Random.Range(0, 360);
        float yRot = Random.Range(0, 360);
        float zRot = Random.Range(0, 360);

        return Quaternion.Euler(xRot, yRot, zRot);
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnDestroy()
    {
        rotate = false;
        StopAllCoroutines();

    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator Spin()
    {
        rotateTarget.rotation = RandomRotation();
        while (rotate)
        {
            rotateTarget.Rotate(rotateTarget.forward * (Time.deltaTime * rotationSpeed * 50));
            yield return null;
        }
    }

}
