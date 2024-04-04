using UnityEngine;
using UnityEngine.UI;

public class ShopDisplay : MonoBehaviour
{
    public ShopSystem shopSystem;
    public Transform shopElementContainer;
    public Button previousButton;
    public Button nextButton;
    public Button buyButton;
    public Button selectButton;

    private int currentElementIndex = 0;
    private GameObject currentShopElementUI;
    private int currentCoins;

    void Start()
    {
        currentCoins = PlayerPrefs.GetInt("Money", 5000);
        LoadBoughtStatus(); // Load the bought status of shop elements at the start of the scene
        DisplayShopElement(currentElementIndex);
        previousButton.onClick.AddListener(ShowPreviousElement);
        nextButton.onClick.AddListener(ShowNextElement);
        buyButton.onClick.AddListener(BuyCurrentElement);
        selectButton.onClick.AddListener(SelectCurrentElement);
    }

    void ShowPreviousElement()
    {
        currentElementIndex--;
        if (currentElementIndex < 0)
        {
            currentElementIndex = shopSystem.shopElements.Count - 1;
        }
        DisplayShopElement(currentElementIndex);
    }

    void ShowNextElement()
    {
        currentElementIndex++;
        if (currentElementIndex >= shopSystem.shopElements.Count)
        {
            currentElementIndex = 0;
        }
        DisplayShopElement(currentElementIndex);
    }

    void BuyCurrentElement()
    {
        ShopElement currentShopElement = shopSystem.shopElements[currentElementIndex];
        currentCoins = PlayerPrefs.GetInt("Money", 5000);
        
        if (currentCoins >= currentShopElement.price)
        {
            int newCoins = currentCoins - currentShopElement.price;
            PlayerPrefs.SetInt("Money", newCoins);
            PlayerPrefs.SetInt(currentShopElement.elementName + "_Bought", 1); // Save the bought status using PlayerPrefs
            CoinAmountScript.instance.coinAmount = newCoins;
            buyButton.interactable = false; // Disabling buy button after purchase
            selectButton.gameObject.SetActive(true); // Enabling select button after purchase
            DisplayShopElement(currentElementIndex); // Refresh the shop element UI
        }
        else
        {
            Debug.Log("Not enough coins");
            // Display a message indicating that there are not enough coins
        }
    }

    void DisplayShopElement(int index)
    {
        if (currentShopElementUI != null)
            Destroy(currentShopElementUI);

        ShopElement currentShopElement = shopSystem.shopElements[index];
        currentShopElementUI = Instantiate(currentShopElement.shopElementPrefab, shopElementContainer);

        Debug.Log(PlayerPrefs.GetInt(currentShopElement.elementName + "_Bought", 0));
        Debug.Log(currentShopElement.elementName);
        // Check if the item is already bought
        if (PlayerPrefs.GetInt(currentShopElement.elementName + "_Bought", 0) == 1)
        {
            // If bought, disable buy button and enable select button
            buyButton.interactable = false;
            selectButton.gameObject.SetActive(true);
        }
        else
        {
            // If not bought, enable buy button and disable select button
            buyButton.interactable = true;
            selectButton.gameObject.SetActive(false);
        }
    }


    void LoadBoughtStatus()
    {
        foreach (ShopElement element in shopSystem.shopElements)
        {
            if (PlayerPrefs.GetInt(element.elementName + "_Bought", 0) == 1)
            {
                element.isBought = true;
            }
        }
    }

    void SelectCurrentElement()
    {
        // Implement your select logic here
        // For example, update game state to indicate the current element is selected
        PlayerPrefs.SetInt("SelectedElement", currentElementIndex);
    }

    public int GetCurrentElementIndex()
    {
        return currentElementIndex;
    }

}
