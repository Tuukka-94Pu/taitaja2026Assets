using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class fuelLogic : MonoBehaviour
{
    public int fuelAmount;
    public TMP_Text fuelText;
    public Slider fuelSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fuelSlider = GameObject.Find("fuelSlider").GetComponent<Slider>();

        fuelAmount = 5000;
        fuelText.text = "Fuel remaining:\n" + fuelAmount;
        fuelSlider.maxValue = fuelAmount;
        fuelSlider.value = fuelAmount;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
    }

    public void UseFuel()
    {
        fuelAmount--;
        fuelAmount--;
        fuelText.text = "Fuel remaining:\n"+fuelAmount;
        fuelSlider.value = fuelAmount;
        if(fuelAmount <= 0)
        {
            GetComponent<playerThings>().death();
        }
    }
}
