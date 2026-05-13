using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tutorialMode : MonoBehaviour
{
    public bool tutStage1;

    public Slider movemntSlider;

    private int tutorialMovementInput , tutorialStage;

    public int tutorialMovementMax;

    public TMP_Text tutorialText;

    private GameObject tutorialButton;

    public GameObject tutorialUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutStage1 = false;
        tutorialStage = 1;
        tutorialText.gameObject.SetActive(false);
        tutorialButton = GameObject.Find("tutorialNextButton");
        tutorialButton.SetActive(false);
        movemntSlider.maxValue = tutorialMovementMax;
    }

    // Update is called once per frame
    void Update()
    {
        if( tutorialMovementInput > tutorialMovementMax && movemntSlider.gameObject.activeSelf == true)
        {      
            movemntSlider.gameObject.SetActive(false);
            tutStage1 = true;
            tutorialText.gameObject.SetActive(true);
            tutorialButton.SetActive(true);
            tutorial2();
        }
       
    }

    public void inputRead()
    {

        tutorialMovementInput++;
        movemntSlider.value = tutorialMovementInput;
    }

    public void whichTutorial()
    {
        switch (tutorialStage)
        {
            case 2:
                tutorial3();
                return;
            case 3:
                tutorial4();
                return;
            case 4:
                EndTutorial();
                return;
            default:
                EndTutorial();
                return;
        }
    }

    private void EndTutorial()
    {
        tutorialText.text = "";
        tutorialButton.SetActive(false);
        tutorialUI.SetActive(false);
    }

    private void tutorial2()
    {
        tutorialText.text = "Fuel is used when moving,\nRunning out results in explosion.";
        tutorialStage = 2;
    }

    private void tutorial3()
    {
        tutorialText.text = "Press TAB To open map \nThe red dot is your objective";
        tutorialStage = 3;
    }

    private void tutorial4()
    {
        tutorialText.text = "Avoid collisions and good luck";
        tutorialStage = 4;
    }
    
}
