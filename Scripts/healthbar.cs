using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class healthbar : MonoBehaviour
{
    public Slider healthBarSlider; //the healthbar itself (or the filling of it)
    public playerStats playerStats; //player script with health functions
    public TextMeshProUGUI healthText; //the number showing the health amount
    void Start()
    {
        ChangeHealth(playerStats.maxHealth);
    }

    public void ChangeHealth(float health) //reference this in the player script when health changes
    {
        healthText.text = health + " / " + playerStats.maxHealth; //Displays the health as numbers :D

        healthBarSlider.value = health; //changes the value of the slider to display current health
    }
}
