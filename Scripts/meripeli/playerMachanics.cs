using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMachanics : MonoBehaviour
{
    public LayerMask interactionLayer;

    public TMP_Text InteractionText;

    public GameObject spotlight;

    public GameObject dirRef;

    public InputAction spotlightToggle;

    public bool PowerOut;

    public InputAction interact;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spotlightToggle.Enable();
        interact = InputSystem.actions.FindAction("interact");
    }

    // Update is called once per frame
    void Update()
    {
        {
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position,  dirRef.transform.right ,1 ,interactionLayer);

            if (Physics2D.Raycast(transform.position, dirRef.transform.right, 1, interactionLayer))
            {

                if (InteractionText.gameObject.activeSelf == false)
                {
                    InteractionText.gameObject.SetActive(true);
                }

                if (interact.WasPressedThisFrame())
                {
                    AudioManager.instance.PlaySound("sample");
                    Destroy(hit2D.collider.gameObject);
                    StartCoroutine(waitJustASec());
                }

            }
            else
            {
                InteractionText.gameObject.SetActive(false);
            }


            if(PowerOut == false)
            {


                if (spotlightToggle.WasPressedThisFrame())
                {
                    if (spotlight.activeSelf == true)
                    {
                        spotlight.SetActive(false);
                    }
                    else
                    {
                        spotlight.SetActive(true);
                    }
                }
            }



        }
    }

    private IEnumerator waitJustASec()
    {
        yield return new WaitForSeconds(0.1f);
        var objective = GameObject.Find("GameManager").GetComponent<GameManager>();
        objective.CheckRemainingObjectives();
    }
    public void powerOFF()
    {
        PowerOut = true;
        spotlight.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("endZone"))
        {
            var manager = GameObject.Find("GameManager").GetComponent<GameManager>();
            manager.OnEndZoneEnter();
        }
        if(collision.CompareTag("slowHazard"))
        {
            AudioManager.instance.PlaySound("splash");
            GetComponent<NEWplayerMovement>().SlowedDown();
            Destroy(collision.gameObject);
        }
    }

}
