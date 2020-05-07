using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Transformed Object", menuName = "Inventory System/Resources/Transformed")]
public class TransformedObject : ResourcesObject
{
    public void Awake()
    {
        type = ResourcesType.Transformed;
    }
}
