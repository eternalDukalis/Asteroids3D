using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Turns on/off interface
/// </summary>
public class UIEnabler : MonoBehaviour {

#pragma warning disable
    [SerializeField]
    GameObject activeObject, unactiveObject;
#pragma warning restore

    void Start ()
    {
        BaseInput.OnUISwitch += Switch;
	}

    private void OnDestroy()
    {
        BaseInput.OnUISwitch -= Switch;
    }

    private void Switch(bool obj)
    {
        activeObject.SetActive(obj);
        unactiveObject.SetActive(!obj);
    }
}
