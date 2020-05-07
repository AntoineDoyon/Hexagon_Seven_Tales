using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Raw Object", menuName = "Inventory System/Resources/Raw")]
public class RawObject : ResourcesObject
{
    public void Awake()
    {
        type = ResourcesType.Raw;     
    }
}
