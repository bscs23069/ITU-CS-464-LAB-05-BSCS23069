
using UnityEngine;
using TMPro;

public class BonusCoinUI : MonoBehaviour
{
    public TMP_Text bonusCounterText;

    private int bonusCoins = 0;

    private void Start()
    {
        if (bonusCounterText != null)
        {
            bonusCounterText.text = "BonusCoins: 0/50";
            bonusCounterText.gameObject.SetActive(false);
        }
    }

    public void ShowBonusCounter()
    {
        bonusCoins = 0;

        if (bonusCounterText != null)
        {
            bonusCounterText.gameObject.SetActive(true);
            UpdateText();
        }
    }

    public void AddBonusCoin()
    {
        bonusCoins = Mathf.Min(bonusCoins + 1, 50);

        UpdateText();
    }

    private void UpdateText()
    {
        if (bonusCounterText != null)
        {
            bonusCounterText.text =
                "BonusCoins: " + bonusCoins + "/50";
        }
    }
}
