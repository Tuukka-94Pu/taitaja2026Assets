using TMPro;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject[] objectives;

    public TMP_Text objectiveCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CheckRemainingObjectives();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckRemainingObjectives()
    {
        objectives = GameObject.FindGameObjectsWithTag("objective");
        objectiveCount.text = "Objectives left: " + objectives.Length;
        if (objectives.Length <= 0)
        {
            winState();
        }
    }

    public void winState()
    {
        objectiveCount.text = "Return to base!";
    }

    public void OnEndZoneEnter()
    {
        if (objectives.Length <= 0)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }

            public void OnDeath()
            {
        SceneManager.LoadScene("Lose");
            }

}
