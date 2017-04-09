using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Selecting quality settings with dropdown
/// </summary>
public class QualitySelector : MonoBehaviour {

    Dropdown drop;

	void Start ()
    {
        drop = GetComponent<Dropdown>();
        if (drop == null)
        {
            Debug.LogError("This is not dropdown.");
            this.enabled = false;
        }
	}

    /// <summary>
    /// Set selected quality settings
    /// </summary>
    public void SetLevel()
    {
        SettingsManager.Instance.SetQuality(drop.value);
    }
}
