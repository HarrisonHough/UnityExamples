using UnityEngine;
using UnityEngine.EventSystems;

public class BallTouchButton : MonoBehaviour
{
    
    public void OnPointerDown(BaseEventData eventData)
    {
        Debug.Log($"Pointer down");
    }

    public void OnPointerUp(BaseEventData eventData)
    {
        Debug.Log($"Pointer UP");
    }
}
