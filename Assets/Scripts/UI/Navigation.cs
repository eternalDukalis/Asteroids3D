using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI navigation
/// </summary>
public class Navigation : MonoBehaviour {

#pragma warning disable
    [SerializeField]
    Image currentScreen;
#pragma warning restore

    Stack<Image> navStack; //Previous scenes will be stored in this stack

	void Start ()
    {
        navStack = new Stack<Image>();
	}

    /// <summary>
    /// Go to new screen
    /// </summary>
    /// <param name="newScreen">New screen's Image component</param>
    public void GoTo(Image newScreen)
    {
        navStack.Push(currentScreen);
        currentScreen.gameObject.SetActive(false);
        currentScreen = newScreen;
        currentScreen.gameObject.SetActive(true);
    }

    /// <summary>
    /// Go back
    /// </summary>
    public void Back()
    {
        if (navStack.Count == 0)
        {
            Debug.LogError("Nowhere to go back");
            return;
        }
        currentScreen.gameObject.SetActive(false);
        currentScreen = navStack.Pop();
        currentScreen.gameObject.SetActive(true);
    }
}
