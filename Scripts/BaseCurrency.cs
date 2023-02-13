using System;
using UnityEngine;

public class BaseCurrency
{
    public event Action<int> OnAdd;
    public event Action<int> OnRemoved;
    public event Action OnChanged;

    private readonly string currencyName;

    public BaseCurrency(string currencyName)
    {
        this.currencyName = currencyName;
    }
    
    public int Value
    {
        get => PlayerPrefs.GetInt(currencyName + "Currency", 0);
        private set => PlayerPrefs.SetInt(currencyName + "Currency", value);
    }
    
    public void Add(int amount)
    {
        Value += amount;
        OnAdd?.Invoke(amount);
        OnChanged?.Invoke();
    }

    public void Remove(int amount)
    {
        Value -= amount;
        OnRemoved?.Invoke(amount);
        OnChanged?.Invoke();
    }

    public bool CanAfford(int amount) => Value >= amount;
}
