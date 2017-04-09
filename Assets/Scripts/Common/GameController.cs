using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for managing game processes
/// </summary>
public class GameController : MonoBehaviour {

#pragma warning disable
    [SerializeField]
    string asteroidDestroyedMessage, asteroidCollidedMessage, portalShiftedMessage;
#pragma warning restore

    static GameController _instance;

    /// <summary>
    /// Cureent GameController instance
    /// </summary>
    public static GameController Instance { get { return _instance; } }

    /// <summary>
    /// When score is changed
    /// </summary>
    public static event System.Action OnScoreChanged;

    /// <summary>
    /// When log is changed
    /// </summary>
    public static event System.Action OnLogChanged;

    const string scenesPath = "Scenes/"; //Directory with scenes
    const string separator = "\n"; //Separates messages in event log

    int _score = 0;
    string _log = "";

    /// <summary>
    /// Current score - number of destroyed asteroids
    /// </summary>
    public int Score { get { return _score; } }

    /// <summary>
    /// Event log
    /// </summary>
    public string Log { get { return _log; } }

	void Awake ()
    {
        if (_instance != null)
            Destroy(_instance);
        _instance = this;
        Asteroid.OnAsteroidDestroy += IncreaseScore;
        Starship.OnAsteroidCollide += InformAboutAsteroidCollide;
        Starship.OnPortalShift += InformAboutPortalShift;
	}

    private void OnDestroy()
    {
        Asteroid.OnAsteroidDestroy -= IncreaseScore;
        Starship.OnAsteroidCollide -= InformAboutAsteroidCollide;
        Starship.OnPortalShift -= InformAboutPortalShift;
    }

    private void InformAboutPortalShift()
    {
        AddToLog(portalShiftedMessage);
        if (OnLogChanged != null)
            OnLogChanged();
    }

    private void InformAboutAsteroidCollide()
    {
        AddToLog(asteroidCollidedMessage);
        if (OnLogChanged != null)
            OnLogChanged();
    }

    private void IncreaseScore()
    {
        _score++;
        if (OnScoreChanged != null)
            OnScoreChanged();
        AddToLog(asteroidDestroyedMessage);
        if (OnLogChanged != null)
            OnLogChanged();
    }

    void AddToLog(string message)
    {
        _log = message + separator + _log;
    }

    /// <summary>
    /// Load new level
    /// </summary>
    /// <param name="sceneName">Level's scene name</param>
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(scenesPath + sceneName);
    }

    /// <summary>
    /// Restart level
    /// </summary>
    public void Restart()
    {
        LoadLevel(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Quit application
    /// </summary>
    public void Quit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
