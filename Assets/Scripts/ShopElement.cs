using UnityEngine;

[CreateAssetMenu(fileName = "NewShopElement", menuName = "Shop/Shop Element")]
public class ShopElement : ScriptableObject
{
    public string elementName;
    public string description;
    public Sprite icon;
    public int price;
    public GameObject shopElementPrefab;
    public bool isBought; // Boolean variable to track whether the element is bought or not
    public bool isSelected; // Boolean variable to track whether the element is selected or not
}
