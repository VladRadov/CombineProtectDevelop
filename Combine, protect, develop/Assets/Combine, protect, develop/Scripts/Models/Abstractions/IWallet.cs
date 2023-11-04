using System;
using UnityEngine.Events;

public interface IWallet
{
    UnityEvent<float> ChangeValueCurrencyEventHandler { get; set; }
    void Add(ICurrency currency);
    void AddRange(params ICurrency[] currencies);
    void Decrease(ICurrency currency);
    bool HasCountCurrencyOnPurchase(ICurrency currency);
}
