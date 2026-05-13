using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playerThings : MonoBehaviour
{
    public Camera mainCam;
    public Camera mapCam;

    public GameObject explosion , failUI;

    public InputAction mapToggle;

    private AudioManager audios;

    public TMP_Text FAIlcause;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam.gameObject.SetActive(true);
        mapCam.gameObject.SetActive(false);
        failUI.gameObject.SetActive(false);
        mapToggle.Enable();
        audios = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mapToggle.WasPressedThisFrame())
        {
            mainCam.gameObject.SetActive(!mainCam.gameObject.activeSelf);
            mapCam.gameObject.SetActive(!mapCam.gameObject.activeSelf);
            GetComponent<GravityEffect>().horizontalVel.gameObject.SetActive(!GetComponent<GravityEffect>().horizontalVel.gameObject.activeSelf);
            GetComponent<GravityEffect>().verticalVel.gameObject.SetActive(!GetComponent<GravityEffect>().verticalVel.gameObject.activeSelf);
            GetComponent<fuelLogic>().fuelText.gameObject.SetActive(!GetComponent<fuelLogic>().fuelText.gameObject.activeSelf);
            GetComponent<fuelLogic>().fuelSlider.gameObject.SetActive(!GetComponent<fuelLogic>().fuelSlider.gameObject.activeSelf);
        }
    }

    public void death()
    {
        audios.playSound("death");
        failUI.gameObject.SetActive(true);
        GetComponent<GravityEffect>().horizontalVel.text = "ERR";
        GetComponent<GravityEffect>().verticalVel.text = "ERR";
        GetComponent<fuelLogic>().fuelText.text = "ERR";
        GetComponent<fuelLogic>().fuelSlider.gameObject.SetActive (false);
        Instantiate(explosion, transform.position, Quaternion.identity);
        mapCam.gameObject.SetActive(false);
        mainCam.gameObject.SetActive(true);

        if (GetComponent<fuelLogic>().fuelAmount <= 0)
        {
            Debug.Log("Death from no fuel");
            FAIlcause.text = "Cause of failure:\nFuel depleted";
        }
        else
        {
            Debug.Log("Death from collision");
            FAIlcause.text = "Cause of failure:\nCollision with object";
        }


            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("collidable"))
        {
          death();
        }
    }
}
