using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameUi, UpgradeUI;

    private int fails;
    private int successes;
    private int days;

    public TMP_Text dayTitle;

    private AudioManager audios;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audios = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audios.PlayMusic("bg");
        UpgradeUI.SetActive(false);
        GameUi.SetActive(true);
        fails = 0;
        days = 1;
        StartCoroutine(Fancyday());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addSuccess()
    {
        audios.PlaySound("success");
        successes++;
        if(successes > 5)
        {
            Debug.Log("Day succesful");
            GameUi.SetActive(false);
            UpgradeUI.SetActive(true);
            GetComponent<UpgradeSystem>().addMonies(successes * 5);
            Time.timeScale = 0;          
        }
    }

    public void addFails()
    {
        audios.PlaySound("fail");
        fails++;
        if(fails > 4)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    public void startNewDay()
    {
        GameUi.SetActive(true);
        UpgradeUI.SetActive(false);
        Time.timeScale = 1;
        days++;
        successes = 0;
        fails = 0;
        GameObject.Find("deli").GetComponent<customerLogic>().patienceLoss += 0.1f;
        StartCoroutine(Fancyday());
    }

    private IEnumerator Fancyday()
    {
        dayTitle.gameObject.SetActive(true);
        dayTitle.text = "Day "+ days;
        yield return new WaitForSeconds(3.5f);
     

        dayTitle.gameObject.SetActive(false);
    }
}
