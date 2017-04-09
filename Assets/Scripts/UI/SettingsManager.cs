using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for settings management
/// </summary>
public class SettingsManager : MonoBehaviour {

    [SerializeField]
    int[] qualityLevelBindings;

    static SettingsManager _instance;

    /// <summary>
    /// Current SettingsManager instance
    /// </summary>
    public static SettingsManager Instance { get { return _instance; } }

	void Start ()
    {
        if (_instance != null)
            Destroy(_instance);
        _instance = this;
	}

    /// <summary>
    /// Set quality level
    /// </summary>
    /// <param name="x">Quality settings number</param>
    public void SetQuality(int num)
    {
        if ((num < 0) || (num >= qualityLevelBindings.Length))
        {
            Debug.LogError("No quality settings related to this number");
            return;
        }
        QualitySettings.SetQualityLevel(qualityLevelBindings[num]);
    }
}
