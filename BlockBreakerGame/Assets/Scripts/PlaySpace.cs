using UnityEngine;

public class PlaySpace : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D topWall;
    [SerializeField]
    private BoxCollider2D bottomWall;
    [SerializeField]
    private BoxCollider2D leftWall;
    [SerializeField]
    private BoxCollider2D rightWall;

    [SerializeField]
    private float wallWidth = 1f;
    public static float MinX;
    public static float MaxX;
    public static float MinY;
    public static float MaxY;

    private Camera gameCamera;

    private void Start()
    {
        gameCamera = Camera.main;
        SetupPlaySpace();
    }

    public void SetupPlaySpace()
    {
        GetWorldPositionValues();
        SetupTopWall();
        SetupBottomWall();
        SetupLeftWall();
        SetupRightWall();
    }

    private void SetupTopWall()
    {
        var size = new Vector2(MaxX - MinX, wallWidth);
        size.x += 2;
        Vector2 offset = new Vector3(size.x / 2f, wallWidth / 2);

        topWall.size = size;
        topWall.offset = offset;
        topWall.transform.position = new Vector3(MinX - 1, MaxY, 0f);
    }

    private void SetupBottomWall()
    {
        var size = new Vector2(MaxX - MinX, wallWidth);
        size.x += 2;
        Vector2 offset = new Vector3(size.x / 2f, -wallWidth / 2);
        
        bottomWall.size = size;
        bottomWall.offset = offset;
        bottomWall.transform.position = new Vector3(MinX - 1, MinY, 0f);

    }

    private void SetupLeftWall()
    {
        var size = new Vector2(wallWidth, MaxY - MinY);
        var offset = new Vector2(-wallWidth / 2, size.y / 2);

        leftWall.size = size;
        leftWall.offset = offset;
        leftWall.transform.position = new Vector3(MinX, MinY);
    }

    private void SetupRightWall()
    {
        var size = new Vector2(wallWidth, MaxY - MinY);
        var offset = new Vector2(wallWidth / 2, size.y / 2);

        rightWall.size = size;
        rightWall.offset = offset;
        rightWall.transform.position = new Vector3(MaxX, MinY);
    }

    private void GetWorldPositionValues()
    {
        MinX = gameCamera.ViewportToWorldPoint(Vector3.zero).x;
        MaxX = gameCamera.ViewportToWorldPoint(Vector3.right).x;
        MinY = gameCamera.ViewportToWorldPoint(Vector3.zero).y;
        MaxY = gameCamera.ViewportToWorldPoint(Vector3.up).y;

        Debug.Log("xMin = " + MinX);
        Debug.Log("xMax" + MaxX);
        Debug.Log("Max size = " + (MaxX - MinX));
    }

}
