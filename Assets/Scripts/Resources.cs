using System.Collections.Generic;
using UnityEngine;
using System;

public class Resources : MonoBehaviour
{
    public static Resources Instance;

    public static Action<ResourceType, int> OnResourceChange;
    
    private Dictionary<ResourceType, int> _resources;

    private void Awake() 
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        _resources = new Dictionary<ResourceType, int>();
    }

    public void AddResource(ResourceType type, int amount)
    {
        if(amount <= 0)
            return;
            
        if(_resources.ContainsKey(type))
        {
            _resources[type] += amount;
        }
        else
        {
            _resources.Add(type, amount);
        }
        OnResourceChange?.Invoke(type, _resources[type]);
    }

    public bool SpendResource(ResourceType type, int amount)
    {
        if(amount <= 0)
            return false;

        if(_resources.ContainsKey(type))
        {
            if(_resources[type] >= amount)
            {
                _resources[type] -= amount;
                OnResourceChange?.Invoke(type, _resources[type]);
                return true;
            }
        }
        return false;
    }
}

public enum ResourceType
{
    Scrap = 0
}
