using System.Collections;
using TMPro;
using UnityEngine;

public class playerStats : MonoBehaviour
{

    public TMP_Text OxygenText;
    public TMP_Text EnergyText;

    public int oxygen;
    public int energy;

    private bool damaged;

    private bool loopRunning;

    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oxygen = 100;
        energy = 100;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (loopRunning == false)
        {
            loopRunning = true;
            StartCoroutine(loseResource());
        }

        if(oxygen <= 0)
        {
            var death = GameObject.Find("GameManager").GetComponent<GameManager>();
            death.OnDeath();
        }
        if (energy <= 0)
        {
            var light = GetComponent<playerMachanics>();
            light.powerOFF();
        }
        OxygenText.text = "Oxygen: " + oxygen + "%";
        EnergyText.text = "Energy: " + energy + "%";

        anim.SetBool("hasHit", damaged);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("refill"))
        {
            refillResource();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("oxygenHazard"))
        {
            AudioManager.instance.PlaySound("stalagmiteHit");
            damaged = true;
            oxygen--;
        }
    }

    private void refillResource()
    {
        oxygen = 100;
        energy = 100;
        damaged = false;
    }


    private IEnumerator loseResource()
    {
        if(oxygen > 0) oxygen--;
        if (damaged) oxygen -= 2;
        if (energy > 0) energy--;
        if(GetComponent<playerMachanics>().spotlight.activeSelf == true) energy--;
        yield return new WaitForSeconds(1.5f);
        loopRunning = false;
    }
}
