using UnityEngine;
using UnityEngine.UI;

public class UIDebugControl : MonoBehaviour
{

    public static UIDebugControl Instance;

    [SerializeField]
    private Text debugText;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ClearDebugText()
    {

    }

    public void AddDebugText(string textToAdd)
    {
        debugText.text += "\n" + textToAdd;
    }
}
