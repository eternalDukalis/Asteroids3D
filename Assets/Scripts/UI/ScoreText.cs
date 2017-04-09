using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Shows score on screen with UI.Text
/// </summary>
public class ScoreText : MonoBehaviour {

    [SerializeField]
    string textFormat = "Destroyed asteroids: {0}";

	void Start () {
        Show();
        GameController.OnScoreChanged += Change;
	}

    private void OnDestroy()
    {
        GameController.OnScoreChanged -= Change;
    }

    private void Change()
    {
        Show();
    }

    void Show()
    {
        GetComponent<Text>().text = string.Format(textFormat, GameController.Instance.Score);
    }
}
