using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game objects pool
/// </summary>
public class GameObjectsPool : MonoBehaviour {

    /// <summary>
    /// Pool size
    /// </summary>
    public int Size { get { return _size; } }

    [SerializeField]
    protected int _size;
    [SerializeField]
    protected GameObject objectPrefab; //Storable object
    [SerializeField]
    protected GameObject parentObject; //Parent object for storable objects
    protected Stack<GameObject> objectsStack; //Stack for objects storage

	protected void Start ()
    {
        //Create(_size);
	}

    /// <summary>
    /// Create pool
    /// </summary>
    /// <param name="size">Initial pool size</param>
    public virtual void Create(int size)
    {
        //Checking ability to create pool
        if (objectPrefab == null)
        {
            Debug.LogError("Object is not exist. Unable to create pool.");
            return;
        }

        _size = size;
        objectsStack = new Stack<GameObject>();

        //Instatiating objects and pushing it into stack
        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.transform.SetParent(parentObject.transform, false);
            Hide(obj);
            objectsStack.Push(obj);
        }
    }

    /// <summary>
    /// Take object from pool
    /// </summary>
    /// <returns></returns>
    public GameObject Take()
    {
        //If pool is empty we need to expand pool
        if (objectsStack.Count == 0)
        {
            GameObject cres = Instantiate(objectPrefab);
            Init(cres);
            _size++;
            return cres;
        }
        GameObject res = objectsStack.Pop();
        Init(res);
        return res;
    }

    /// <summary>
    /// Retrun object to pool
    /// </summary>
    /// <param name="obj">Returned object</param>
    public virtual void Release(GameObject obj)
    {
        Hide(obj);
        objectsStack.Push(obj);
    }

    /// <summary>
    /// Set object
    /// </summary>
    /// <param name="obj">Target object</param>
    public virtual void Init(GameObject obj)
    {
        obj.SetActive(true);
    }

    //Hide object
    protected void Hide(GameObject obj)
    {
        obj.SetActive(false);
    }
}
