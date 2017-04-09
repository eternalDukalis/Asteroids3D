using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Portal info
/// </summary>
public class Portal : MonoBehaviour {

    [SerializeField]
    string sceneName;

    /// <summary>
    /// Name of the scene where the portal leads to
    /// </summary>
    public string SceneName { get { return sceneName; } }
}
