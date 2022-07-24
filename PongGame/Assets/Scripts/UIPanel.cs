using System;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    private GameObject[] childObjects;
    
    protected virtual void Awake()
    {
        if (childObjects.Length < 1)
        {
            SetupChildObjectsArray();
        }
    }
    
    private void Start()
    {
        throw new NotImplementedException();
    }
    public void ShowPanel()
    {
        SetPanelActive(true);
    }

    public void HidePanel()
    {
        SetPanelActive(false);
    }

    protected void SetPanelActive(bool active)
    {
        foreach (var childObject in childObjects)
        {
            childObject.SetActive(active);
        }
    }

    [ContextMenu("Setup Child Objects Array")]
    public void SetupChildObjectsArray()
    {
        childObjects = new GameObject[transform.childCount];
    }
}
