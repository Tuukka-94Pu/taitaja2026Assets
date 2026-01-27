using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class maimenu : MonoBehaviour
{
    private GameObject start;

    private GameObject exit;

    private GameObject TitleText;

    public string NameOfGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start = GameObject.Find("start");
        start.GetComponent<Button>().GetComponentInChildren<TMP_Text>().text = "Start game";
        exit = GameObject.Find("exit");
        exit.GetComponent<Button>().GetComponentInChildren<TMP_Text>().text = "Exit game";
        TitleText = GameObject.Find("title");
        TitleText.GetComponent<TMP_Text>().text = NameOfGame;
    }

}
