using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourcesType
{
    Raw,
    Transformed,
    Asset,
}

public abstract class ResourcesObject : ScriptableObject
{
    public GameObject prefab;
    public ResourcesType type;
    [TextArea(15,20)]
    public string description;
}
