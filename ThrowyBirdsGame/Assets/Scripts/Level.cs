using UnityEngine;
using UnityEngine.Serialization;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2019
* VERSION: 1.0
* SCRIPT: Level Class
*/

/// <summary>
/// This class holds references to objects that other 
/// classes need to access. It also ensures that GameManager
/// calls "OnLevelStart" each time the scene is loaded.
/// (GameManager does not destroy on load so start only runs once)
/// </summary>
public class Level : MonoBehaviour
{
    //store reference to birds array
    [FormerlySerializedAs("_birds"), SerializeField]
    private Bird[] birds;
    public Bird[] Birds => birds;

    //store reference to enemy array
    [FormerlySerializedAs("_enemies"), SerializeField]
    private Enemy[] enemies;
    public Enemy[] Enemies => enemies;

    //store reference to UI Control
    [FormerlySerializedAs("_uiControl"), SerializeField]
    private UIControl uiControl;
    public UIControl UIControl => uiControl;

    private void Awake()
    {
        GameManager.Instance.OnLevelStart(this);
    }
}
