using UnityEngine;
using System.Collections.Generic;

public class ShopSystem : MonoBehaviour
{
    public List<ShopElement> shopElements = new List<ShopElement>();

    public void AddShopElement(ShopElement shopElement)
    {
        shopElements.Add(shopElement);
    }

    public void RemoveShopElement(int index)
    {
        if (index >= 0 && index < shopElements.Count)
        {
            shopElements.RemoveAt(index);
        }
    }
}
