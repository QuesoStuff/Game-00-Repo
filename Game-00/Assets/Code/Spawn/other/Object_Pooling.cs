using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object_Pooling : MonoBehaviour
{
    [SerializeField] protected Queue<GameObject> pool_ = new Queue<GameObject>();
    [SerializeField] protected List<GameObject> entities_ = new List<GameObject>();

    // Your pool related methods and variables go here, such as:
    [SerializeField] protected int maxEntities_ = 100;

    public abstract void CleanUpEntities();

}
