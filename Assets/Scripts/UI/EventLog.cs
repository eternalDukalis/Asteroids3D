using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Shows event log
/// </summary>
public class EventLog : MonoBehaviour {

	void Start ()
    {
        Show();
        GameController.OnLogChanged += Change;
	}

    private void OnDestroy()
    {
        GameController.OnLogChanged -= Change;
    }

    private void Change()
    {
        Show();
    }

    void Show()
    {
        GetComponent<Text>().text = GameController.Instance.Log;
    }
}
