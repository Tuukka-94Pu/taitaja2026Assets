using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class objectives : MonoBehaviour
{

    public bool beenToMoon;

    public GameObject moonMarker, earthMarker;

    public TMP_Text objectiveText;

    public Transform moonObjectivePoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beenToMoon = false;
        moonMarker.SetActive(true);
        earthMarker.SetActive(false);
        objectiveText.text = "current objective:\nreach moon's dark side";
    }

    // Update is called once per frame
    void Update()
    {
        if (beenToMoon == false)
        {
            var distanceToMonObj = Vector2.Distance(transform.position , moonObjectivePoint.position);
            if (distanceToMonObj <= 10f)
            {
                beenToMoon = true;
                earthMarker.SetActive(true);
                moonMarker.SetActive(false);
                objectiveText.text = "current objective:\nreturn to earth";
            }
        }

        if (beenToMoon == true)
        {
            Transform earth = GameObject.Find("earthCenter").transform;
            var distanceToEarth = Vector2.Distance(transform.position ,earth.position);

            if(distanceToEarth <= 30f)
                {
                SceneManager.LoadScene("Win");
            }
        }


        
    }

}
