using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDebugControl : MonoBehaviour {

    public static UIDebugControl Instance;

    [SerializeField]
    private Text _debugText;
	// Use this for initialization
	void Awake () {
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
        _debugText.text += "\n" + textToAdd;
    }
}
