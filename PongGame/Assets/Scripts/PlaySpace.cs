using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Play Space Class 
*/


/// <summary>
/// This class dynamically positions and resizes the 
/// boundary colliders in world space by converting 
/// screen coordinates to world coordinates
/// </summary>
public class PlaySpace : MonoBehaviour
{

    //reference to all 4 wall colliders
    [SerializeField]
    private BoxCollider2D _topWall;
    [SerializeField]
    private BoxCollider2D _bottomWall;
    [SerializeField]
    private BoxCollider2D _leftWall;
    [SerializeField]
    private BoxCollider2D _rightWall;

    //used to determine width of walls, can be changed in editor
    [SerializeField]
    private float _wallWidth = 1f;

    [SerializeField]
    private bool _adjustSprite = false;
    public static float XMin;
    public static float XMax;
    public static float YMin;
    public static float YMax;

    /// <summary>
    /// Used for initialization on scene start
    /// </summary>
    private void Start()
    {

        SetupPlaySpace();

    }

    /// <summary>
    /// 
    /// </summary>
    public void SetupPlaySpace()
    {
        GetWorldPositionValues();
        SetupTopWall();
        SetupBottomWall();
        SetupLeftWall();
        SetupRightWall();
    }

    /// <summary>
    /// Sets up the top wall colliders size and position
    /// </summary>
    private void SetupTopWall()
    {

        Vector2 size = new Vector2(XMax - XMin, _wallWidth);
        size.x += 2;
        Vector2 offset = new Vector3(size.x / 2f, _wallWidth / 2);

        _topWall.size = size;
        _topWall.offset = offset;
        _topWall.transform.position = new Vector3(XMin - 1, YMax, 0f);
    }

    /// <summary>
    /// Sets up the bottom wall colliders size and position
    /// </summary>
    private void SetupBottomWall()
    {

        Vector2 size = new Vector2(XMax - XMin, _wallWidth);
        size.x += 2;
        Vector2 offset = new Vector3(size.x / 2f, -_wallWidth / 2);

        //Bottom wall position logic
        _bottomWall.size = size;
        _bottomWall.offset = offset;
        _bottomWall.transform.position = new Vector3(XMin - 1, YMin, 0f);

    }

    /// <summary>
    /// Sets up the left wall colliders size and position
    /// </summary>
    private void SetupLeftWall()
    {
        Vector2 size = new Vector2(_wallWidth, YMax - YMin);
        Vector2 offset = new Vector3(-_wallWidth / 2, size.y / 2);

        _leftWall.size = size;
        _leftWall.offset = offset;
        _leftWall.transform.position = new Vector3(XMin, YMin);
    }

    /// <summary>
    /// Sets up the right wall colliders size and position
    /// </summary>
    private void SetupRightWall()
    {
        Vector2 size = new Vector2(_wallWidth, YMax - YMin);
        Vector2 offset = new Vector3(_wallWidth / 2, size.y / 2);

        _rightWall.size = size;
        _rightWall.offset = offset;
        _rightWall.transform.position = new Vector3(XMax, YMin);

    }

    /// <summary>
    /// Converts the viewport boundary coordinates to world 
    /// coordinates
    /// </summary>
    private void GetWorldPositionValues()
    {
        XMin = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        XMax = Camera.main.ViewportToWorldPoint(Vector3.right).x;
        YMin = Camera.main.ViewportToWorldPoint(Vector3.zero).y;
        YMax = Camera.main.ViewportToWorldPoint(Vector3.up).y;
    }

}
