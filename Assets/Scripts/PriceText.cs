using UnityEngine;
using TMPro;

public class PriceText : MonoBehaviour
{
    public ShopDisplay shopDisplay; // Reference to the ShopDisplay script
    private TextMeshProUGUI priceText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        // Get the TextMeshProUGUI component attached to this GameObject
        priceText = GetComponent<TextMeshProUGUI>();
        
        // Ensure that the reference to ShopDisplay script is set
        if (shopDisplay == null)
        {
            Debug.LogError("ShopDisplay reference is not set in PriceText script!");
            return;
        }

        // Update the price text initially
        UpdatePriceText();
    }

    void Update()
    {
        // Update the price text dynamically every frame (optional)
        // You can remove this if you only want to update the price text when the selected element changes
        UpdatePriceText();
    }

    void UpdatePriceText()
    {
        // Get the current selected shop element index from ShopDisplay script
        int currentIndex = shopDisplay.GetCurrentElementIndex();

        // Ensure that the index is valid
        if (currentIndex >= 0 && currentIndex < shopDisplay.shopSystem.shopElements.Count)
        {
            // Get the price of the current selected shop element
            int price = shopDisplay.shopSystem.shopElements[currentIndex].price;

            // Update the price text
            priceText.text = "Price: " + price.ToString(); // Assuming the price is an integer
        }
    }
}
