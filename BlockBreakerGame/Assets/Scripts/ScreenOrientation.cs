using UnityEngine;

public class ScreenOrientation : MonoBehaviour
{
    public enum Orientation { Portrait, LandscapeLeft, LandscapeRight, Landscape }
    public Orientation screenOrientation;

    private PlaySpace playSpace;

    void Start()
    {
        playSpace = FindObjectOfType<PlaySpace>();
        SetOrientation();
    }

    void SetOrientation()
    {
        switch (screenOrientation)
        {
            case Orientation.Portrait:
                Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
                if (UIDebugControl.Instance != null)
                    UIDebugControl.Instance.AddDebugText("Setting to portrait mode");
                if (Screen.width > Screen.height)
                {
                    if (UIDebugControl.Instance != null)
                        UIDebugControl.Instance.AddDebugText("Setting portrait resolution");
                    SetResolution();
                }
                break;
            case Orientation.LandscapeLeft:
                Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;
                if (Screen.width < Screen.height)
                {
                    SetResolution();
                }
                break;
            case Orientation.LandscapeRight:
                Screen.orientation = UnityEngine.ScreenOrientation.LandscapeRight;
                if (Screen.width < Screen.height)
                {
                    SetResolution();
                }
                break;

            default:
                Debug.Log("Something wen wrong in switch");
                break;

        }

        if (playSpace == null) return;
        playSpace.SetupPlaySpace();
    }

    void SetResolution()
    {
        var width = Screen.width;
        var height = Screen.height;
        Screen.SetResolution(height, width, false);
    }
}
