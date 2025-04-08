using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeController : MonoBehaviour
{
    public GameObject obj1, obj2;

    /// <summary>
    /// Increase sphere scale
    /// </summary>
    public void Grow()
    {
        obj1.transform.localScale *= 1.25f;
        obj2.transform.localScale *= 1.25f;
    }

    /// <summary>
    /// Decrease sphere scale
    /// </summary>
    public void Shrink()
    {
        obj1.transform.localScale /= 1.25f;
        obj2.transform.localScale /= 1.25f;
    }

}
