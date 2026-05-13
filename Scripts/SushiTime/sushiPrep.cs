using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class sushiPrep : MonoBehaviour
{
    private InputAction use;
    private bool canPrep,canRice,canCarrot,canKelp,canFish,canCucumber;

    public GameObject deliPoint;

    public TMP_Text ITEMS, interactText;

    public List<string> plateContents;

    private List<string> SushiRecipe = new List<string>();

    private AudioManager audios;

    public ParticleSystem chop;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        use = InputSystem.actions.FindAction("interact");
        audios = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        canPrep = false;
        plateContents.Clear();
        SushiRecipe.Add("rice");
        UpdateHoldingList();
    }

    // Update is called once per frame
    void Update()
    {
        if(use.WasPressedThisFrame())
        {
            if ( canPrep == true)
            {
                MAKETHESUSHI();
            }
            if(canRice == true) 
                {
                    if (plateContents.Contains("rice")) return;
                    else plateContents.Add("rice");
                audios.PlaySound("slush");
                }
            if (canKelp == true)
            {
                if (plateContents.Contains("kelp")) return;
                else plateContents.Add("kelp");
                audios.PlaySound("slush");
            }
            if (canCarrot == true)
            {
                if (plateContents.Contains("carrot")) return;
                else plateContents.Add("carrot");
                audios.PlaySound("slush");
            }
            if (canFish == true)
            {
                if (plateContents.Contains("fish")) return;
                else plateContents.Add("fish");
                audios.PlaySound("slush");
            }
            if (canCucumber == true)
            {
                if (plateContents.Contains("cucumber")) return;
                else plateContents.Add("cucumber");
                audios.PlaySound("slush");
            }
            UpdateHoldingList();

        }

    }

    private void MAKETHESUSHI()
    {
        if (plateContents.Contains("rice") && plateContents.Contains("carrot") && plateContents.Contains("cucumber") && plateContents.Contains("kelp") && plateContents.Contains("fish"))
        {
            plateContents.Remove("rice");
            plateContents.Remove("kelp");
            plateContents.Remove("carrot");
            plateContents.Remove("cucumber");
            plateContents.Remove("fish");
            plateContents.Add("Maki");
            audios.PlaySound("chop");
            chop.Play();
        }
        if (plateContents.Contains("rice") && plateContents.Contains("carrot") && plateContents.Contains("cucumber") && plateContents.Contains("kelp"))
        {
            plateContents.Remove("rice");
            plateContents.Remove("kelp");
            plateContents.Remove("carrot");
            plateContents.Remove("cucumber");
            plateContents.Add("Vegan maki");
            audios.PlaySound("chop");
            chop.Play();
        }
        if (plateContents.Contains("fish") && plateContents.Contains("rice"))
        {
            plateContents.Remove("fish");
            plateContents.Remove("rice");
            plateContents.Add("Nigiri");
            audios.PlaySound("chop");
            chop.Play();
        }
        
       


        UpdateHoldingList();
    }

    private void UpdateHoldingList()
    {
        string itemString = "";

        foreach (string item in plateContents)
        {
            itemString = itemString + "-" + item + "\n";
        }
        ITEMS.text = itemString;
    }


    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            default:
                return;
            case "prepZone":
                interactText.text = "E to attempt food prep";
                canPrep = true;
                break;
            case "riceZone":
                interactText.text = "E to pick rice";
                canRice = true;
                break;
            case "kelpZone":
                interactText.text = "E to pick kelp";
                canKelp = true;
                break;
            case "carrotZone":
                interactText.text = "E to pick carrot";
                canCarrot = true;
                break;
            case "cucumberZone":
                interactText.text = "E to pick cucumber";
                canCucumber = true;
                 break;
            case "fishZone":
                interactText.text = "E to pick fish";
                canFish = true;
                break;
            case "delizone":
               var ord = deliPoint.GetComponent<customerLogic>().order;
                if (plateContents.Contains(ord)) 
                {
                    deliPoint.GetComponent<customerLogic>().reroll();
                    GameObject.Find("GameManager").GetComponent<GameManager>().addSuccess();
                    if(GameObject.Find("GameManager").GetComponent<tutorial>().tutorializing == true) GameObject.Find("GameManager").GetComponent<tutorial>().EndTutorial();
                    plateContents.Remove(ord);
                    UpdateHoldingList();
                }
                else GameObject.Find("GameManager").GetComponent<GameManager>().addFails();
                break;
            case "trashZone":
                plateContents.Clear();
                UpdateHoldingList();
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            default:
                return;
            case "prepZone":
                canPrep = false;
                break;
            case "riceZone":
                canRice = false;
                break;
            case "kelpZone":
                canKelp = false;
                break;
            case "carrotZone":
                canCarrot = false;
                break;
            case "cucumberZone":
                canCucumber = false;
                break;
            case "fishZone":
                canFish = false;
                break;

        }
        interactText.text = "";
    }
}
