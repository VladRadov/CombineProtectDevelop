using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : IWallet
{
    private Dictionary<Type, ICurrency> _money;

    public Wallet()
    {
        ChangeValueCurrencyEventHandler = new UnityEvent<float>();
        _money = new Dictionary<Type, ICurrency>();
    }

    public UnityEvent<float> ChangeValueCurrencyEventHandler { get; set; }

    private void InvokeEventChangeValueCurrency(float currency)
    {
        if (ChangeValueCurrencyEventHandler != null)
            ChangeValueCurrencyEventHandler.Invoke(currency);
    }

    public void AddRange(params ICurrency[] currencies)
    {
        foreach (var currency in currencies)
            Add(currency);
    }

    public void Add(ICurrency currency)
    {
        if (_money.ContainsKey(currency.GetType()) == false)
            _money.Add(currency.GetType(), currency);
        else
            _money[currency.GetType()].Value += currency.Value;

        InvokeEventChangeValueCurrency(_money[currency.GetType()].Value);
    }

    public void Decrease(ICurrency currency)
    {
        if (_money.ContainsKey(currency.GetType()))
        {
            _money[currency.GetType()].Value -= currency.Value;
            InvokeEventChangeValueCurrency(_money[currency.GetType()].Value);
            Debug.Log(_money[currency.GetType()].Value.ToString() + "-" + currency.Value.ToString());
        }
    }

    public bool HasCountCurrencyOnPurchase(ICurrency currency)
    {
        if (_money.ContainsKey(currency.GetType()))
            return _money[currency.GetType()].Value >= currency.Value ? true : false;

        return false;
    }
}
