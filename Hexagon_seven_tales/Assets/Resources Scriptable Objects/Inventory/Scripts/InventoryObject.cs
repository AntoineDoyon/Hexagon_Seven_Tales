using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddResource(ResourcesObject _resource, int _amount)
    {
        bool hasResource = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if(Container[i].resource == _resource)
            {
                Container[i].AddAmount(_amount);
                hasResource = true;
                break;
            }
        }
        if(!hasResource)
        {
            Container.Add(new InventorySlot(_resource, _amount));
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ResourcesObject resource;
    public int amount;
    public InventorySlot(ResourcesObject _resource, int _amount)
    {
        resource = _resource;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }

}