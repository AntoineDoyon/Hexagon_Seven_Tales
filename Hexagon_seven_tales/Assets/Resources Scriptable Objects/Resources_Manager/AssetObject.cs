using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Asset Object", menuName = "Inventory System/Resources/Asset")]
public class AssetObject : ResourcesObject
{
    public float prodRateBonus;
    public float civicRateBonus;
    public float militaryRateBonus;
    public bool IsNewRaw;
    public float atkBonus;
    public float defenseBonus;

    public void Awake()
    {
        type = ResourcesType.Asset;
    }
}
