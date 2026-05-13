using System.Collections;
using TMPro;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{

    public GameObject TutorialDoor;

    public GameObject TutorialUI;

    public GameObject movementKeys;

    public GameObject interactKeys;

    public GameObject spotligthKey;

    public GameObject stationUi;

    public GameObject samplesUI;

    public TMP_Text tutorialText;

    public string[] tutorialTexts;

    private int tutorialTextsIndex;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorialTextsIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tutorialText.text = tutorialTexts[tutorialTextsIndex];
    }

    public void EndTutorial()
    {
        Debug.Log("tutorial ended");
        TutorialUI.SetActive(false); TutorialDoor.SetActive(false);
        tutorialTextsIndex = 0;
    }

    public void AdvanceTutorial()
    {

        
        
            tutorialTextsIndex++;
        
        if(tutorialTextsIndex >= tutorialTexts.Length)
        {
            EndTutorial();
        }
        whichUIElements();

    }

    public void whichUIElements()
    {
        switch (tutorialTextsIndex)
        {
            default: return;
            case 0:
                movementKeys.SetActive(true);
                interactKeys.SetActive(false);
                spotligthKey.SetActive(false);
                stationUi.SetActive(false);
                samplesUI.SetActive(false);
                return;
            case 1:
                movementKeys.SetActive(false);
                interactKeys.SetActive(false);
                spotligthKey.SetActive(true);
                stationUi.SetActive(false);
                samplesUI.SetActive(false);
                return;
            case 2:
                movementKeys.SetActive(false);
                interactKeys.SetActive(false);
                spotligthKey.SetActive(false);
                stationUi.SetActive(true);
                samplesUI.SetActive(false);
                return;
            case 3:
                movementKeys.SetActive(false);
                interactKeys.SetActive(true);
                spotligthKey.SetActive(false);
                stationUi.SetActive(false);
                samplesUI.SetActive(false);
                return;
            case 4:
                movementKeys.SetActive(false);
                interactKeys.SetActive(false);
                spotligthKey.SetActive(false);
                stationUi.SetActive(false);
                samplesUI.SetActive(true);
                return;

        }
    }
}
