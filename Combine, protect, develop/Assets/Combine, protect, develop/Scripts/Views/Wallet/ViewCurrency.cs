using UnityEngine;
using UnityEngine.UI;

public class ViewCurrency : ViewBaseWallet
{
    [SerializeField] private Text _count;

    public string Count { get { return _count.text.ToString(); } set { _count.text = value; } }

    public void UpdateCurrency(float valueCarrency) => _count.text = valueCarrency.ToString();
}