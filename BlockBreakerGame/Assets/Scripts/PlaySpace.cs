using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySpace : MonoBehaviour {

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
    //[SerializeField]
    //private bool adjustSprite = false;
    public static float xMin;
    public static float xMax;
    public static float yMin;
    public static float yMax;

	// Use this for initialization
	private void Start () {

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

        Vector2 size = new Vector2(xMax - xMin, wallWidth);
        size.x += 2;
        Vector2 offset = new Vector3(size.x / 2f, wallWidth /2);

        topWall.size = size;
        topWall.offset = offset;
        topWall.transform.position = new Vector3(xMin-1, yMax, 0f);
    }

    private void SetupBottomWall()
    {

        Vector2 size = new Vector2(xMax - xMin, wallWidth);
        size.x += 2;
        Vector2 offset = new Vector3(size.x / 2f, -wallWidth/2);

        //Bottom wall position logic
        bottomWall.size = size;
        bottomWall.offset = offset;
        bottomWall.transform.position = new Vector3(xMin-1, yMin, 0f);

    }

    private void SetupLeftWall()
    {
        Vector2 size = new Vector2(wallWidth, yMax - yMin);
        Vector2 offset = new Vector3(-wallWidth/2, size.y / 2);

        leftWall.size = size;
        leftWall.offset = offset;
        leftWall.transform.position = new Vector3(xMin, yMin);
    }

    private void SetupRightWall()
    {
        Vector2 size = new Vector2(wallWidth, yMax - yMin);
        Vector2 offset = new Vector3(wallWidth/2, size.y / 2);

        rightWall.size = size;
        rightWall.offset = offset;
        rightWall.transform.position = new Vector3(xMax, yMin);

    }

    private void GetWorldPositionValues()
    {
        xMin = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        xMax = Camera.main.ViewportToWorldPoint(Vector3.right).x;
        yMin = Camera.main.ViewportToWorldPoint(Vector3.zero).y;
        yMax = Camera.main.ViewportToWorldPoint(Vector3.up).y;

        Debug.Log("xMin = " + xMin);
        Debug.Log("xMax" + xMax);
        Debug.Log("Max size = " + (xMax - xMin));
    }

}
