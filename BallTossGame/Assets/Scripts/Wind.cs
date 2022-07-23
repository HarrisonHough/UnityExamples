using UnityEngine;
using Random = UnityEngine.Random;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: WindZone Class 
*/

public static class Wind 
{
    private static readonly float minSpeed = 0f;
    private static readonly float maxSpeed = 2f;
    
    private static readonly Vector3 windDirection = Vector3.right;
    private static float windSpeed = 0;

    public static Vector3 windForce;
    public static float WindSpeed
    {
        get => windSpeed;
        set => windSpeed = value;
    }
    
    public static bool windActive = false;

    public static string GetReadableWindSpeed()
    {
        var speed = Mathf.Abs(windSpeed).Remap(minSpeed, maxSpeed, 0, 6);
        return speed.ToString("F1");
    }

    public static void RandomWindStrength(bool randomDirection)
    {
        windSpeed = Random.Range(minSpeed,maxSpeed);

        if (randomDirection && Random.Range(0, 2) < 1)
        {
            windSpeed *= -1;
        }

        windForce = windDirection * windSpeed;
    }
}
