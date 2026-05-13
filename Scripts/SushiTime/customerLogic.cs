using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class customerLogic : MonoBehaviour
{
    private float patience;

    public int maxPatience;

    public float patienceLoss;

    public string order;

    public Slider patienceBar;

    public TMP_Text orderText;

    public List<string> orderTypes;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxPatience = 800;
        patience = 800;
        patienceLoss = 1;
        patienceBar.maxValue = maxPatience;
        patienceBar.value = patience;
        var randomOrder = Random.Range(0, orderTypes.Count);
        order = orderTypes[randomOrder];
    }

    // Update is called once per frame
    void Update()
    {
        orderText.text = order;
    }

    private void FixedUpdate()
    {
        var isTutorial = GameObject.Find("GameManager").GetComponent<tutorial>().tutorializing;
        if (isTutorial == false)
        {
            patience -= patienceLoss;
            patienceBar.value = patience;
            if (patience < 0)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().addFails();
                GameObject.Find("player").GetComponent<Animator>().Play("failed");
                reroll();
            }
        }
    }

    public void reroll()
    {
        var randomOrder = Random.Range(0, orderTypes.Count);
        order = orderTypes[randomOrder];
        patience = maxPatience;
    }
}
