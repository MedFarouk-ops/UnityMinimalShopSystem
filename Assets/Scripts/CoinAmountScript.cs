using UnityEngine;
using TMPro;

public class CoinAmountScript : MonoBehaviour
{
    TextMeshProUGUI text;
    public int coinAmount;

    public static CoinAmountScript instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        coinAmount = PlayerPrefs.GetInt("Money", 5000);
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = coinAmount.ToString();
    }

    public void ResetScore()
    {
        coinAmount = 0;
    }
}
