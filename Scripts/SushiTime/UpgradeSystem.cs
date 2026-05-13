using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    private int monies;

    private int exponentialPrice , monieBonus;

    public TMP_Text moniesLeft, allPrices;

    public Button spedUpg, patiencUpg, moniesUpg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        monies = 0;
        monieBonus = 0;
        exponentialPrice = 0;
    }

    // Update is called once per frame
    void Update()
    {
        moniesLeft.text = "Money left: "+ monies;
        allPrices.text = "Price for upgrades: " + (10 + exponentialPrice);

        
    }

    public void addMonies(int howmuch)
    {
        monies += howmuch + monieBonus;
    }

    public void SpeedUp()
    {
        if (monies >= 10 + exponentialPrice)
        {
            
            GameObject.Find("player").GetComponent<playerMove>().speedMult += 0.2f;
            monies -= 10 + exponentialPrice;
            exponentialPrice += 2;
            if(GameObject.Find("player").GetComponent<playerMove>().speedMult == 12) spedUpg.enabled = false;
        }
    }
    public void PatienceUp()
    {
        if (monies >= 10 + exponentialPrice)
        {
            
            GameObject.Find("deli").GetComponent<customerLogic>().maxPatience += 25;
            monies -= 10 + exponentialPrice;
            exponentialPrice += 2;
            if(GameObject.Find("deli").GetComponent<customerLogic>().maxPatience == 1200) patiencUpg.enabled = false;
        }
    }

    public void monieUp()
    {
        if(monies >= 50)
        {
            monieBonus = 20;
            moniesUpg.enabled = false;
        }

    }
}
