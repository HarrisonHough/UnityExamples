using UnityEngine;
using UnityEngine.Serialization;

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
    private BoxCollider2D topWall;
    [SerializeField]
    private BoxCollider2D bottomWall;
    [SerializeField]
    private BoxCollider2D leftWall;
    [SerializeField]
    private BoxCollider2D rightWall;

    //used to determine width of walls, can be changed in editor
    [SerializeField]
    private float wallWidth = 1f;

    [SerializeField]
    private bool adjustSprite;
    public static float MinX;
    public static float MaxX;
    public static float MinY;
    public static float MaxY;
    private Camera gameCamera;

    /// <summary>
    /// Used for initialization on scene start
    /// </summary>
    private void Start()
    {
        gameCamera = Camera.main;
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
        var size = new Vector2(MaxX - MinX, wallWidth);
        size.x += 2;
        Vector2 offset = new Vector3(size.x / 2f, wallWidth / 2);

        topWall.size = size;
        topWall.offset = offset;
        topWall.transform.position = new Vector3(MinX - 1, MaxY, 0f);
    }

    /// <summary>
    /// Sets up the bottom wall colliders size and position
    /// </summary>
    private void SetupBottomWall()
    {

        var size = new Vector2(MaxX - MinX, wallWidth);
        size.x += 2;
        Vector2 offset = new Vector3(size.x / 2f, -wallWidth / 2);

        //Bottom wall position logic
        bottomWall.size = size;
        bottomWall.offset = offset;
        bottomWall.transform.position = new Vector3(MinX - 1, MinY, 0f);
    }

    /// <summary>
    /// Sets up the left wall colliders size and position
    /// </summary>
    private void SetupLeftWall()
    {
        var size = new Vector2(wallWidth, MaxY - MinY);
        var offset = new Vector2(-wallWidth / 2, size.y / 2);

        leftWall.size = size;
        leftWall.offset = offset;
        leftWall.transform.position = new Vector3(MinX, MinY);
    }

    /// <summary>
    /// Sets up the right wall colliders size and position
    /// </summary>
    private void SetupRightWall()
    {
        var size = new Vector2(wallWidth, MaxY - MinY);
        var offset = new Vector3(wallWidth / 2, size.y / 2);

        rightWall.size = size;
        rightWall.offset = offset;
        rightWall.transform.position = new Vector3(MaxX, MinY);

    }

    /// <summary>
    /// Converts the viewport boundary coordinates to world 
    /// coordinates
    /// </summary>
    private void GetWorldPositionValues()
    {
        MinX = gameCamera.ViewportToWorldPoint(Vector3.zero).x;
        MaxX = gameCamera.ViewportToWorldPoint(Vector3.right).x;
        MinY = gameCamera.ViewportToWorldPoint(Vector3.zero).y;
        MaxY = gameCamera.ViewportToWorldPoint(Vector3.up).y;
    }
}
