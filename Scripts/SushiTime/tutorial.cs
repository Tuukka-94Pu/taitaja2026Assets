using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    public bool tutorializing;

    public TMP_Text tutorialText;

    public Button nextButton;

    private int stage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorializing = true;
        tutorialText.text = "Welcome new chef, move around with WASD";
        stage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void advanceStage()
    {
        stage++;

        switch (stage)
        {
            default:
                break;
            case 1:
                tutorialText.text = "At the bottom of the screen you see the customers order";
                break;
            case 2:
                tutorialText.text = "Gather the needed ingredients from the counters around the kitchen.\n" +
                    "Instructions for the dishes on the left side of screen";
                break;
            case 3:
                tutorialText.text = "Once all needed ingredients are gathered, use the prep area to make the dish.\n" +
                    "It's the chopping board with a knife";
                break;
            case 4:
                tutorialText.text ="Now make the order";
                nextButton.gameObject.SetActive(false);
                break;
        }
    }

    public void EndTutorial()
    {
        tutorialText.text = "Thats all, good luck on the job";
        tutorializing = false;
        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        tutorialText.gameObject.SetActive(false);
    }

}
