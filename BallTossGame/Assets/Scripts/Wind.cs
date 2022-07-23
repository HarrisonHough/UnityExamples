using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2021
* VERSION: 1.0
* SCRIPT: WindZone Class 
*/

public static class Wind
{
    private const float MIN_SPEED = 0f;
    private const float MAX_SPEED = 2f;

    private static readonly Vector3 WindDirection = Vector3.right;
    private static float windSpeed;

    public static Vector3 WindForce;
    private const string SPEED_TEXT_FORMAT = "F1";
    public static float WindSpeed
    {
        get => windSpeed;
        set => windSpeed = value;
    }

    public static bool WindActive = false;

    public static string GetReadableWindSpeed()
    {
        var speed = Mathf.Abs(windSpeed).Remap(MIN_SPEED, MAX_SPEED, 0, 6);
        return speed.ToString(SPEED_TEXT_FORMAT);
    }

    public static void RandomWindStrength(bool randomDirection)
    {
        windSpeed = Random.Range(MIN_SPEED, MAX_SPEED);

        if (randomDirection && Random.Range(0, 2) < 1)
        {
            windSpeed *= -1;
        }

        WindForce = WindDirection * windSpeed;
    }
}
