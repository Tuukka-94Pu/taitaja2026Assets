using Unity.VisualScripting;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    public int health;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 100;        
    }

    // Update is called once per frame
    void Update()
    {

        if(health <= 0)
        {
            OnDeath();
        }

    }
    public void takeDamage(int damage)
    {
        health -= damage;
    }

    public void OnDeath()
    {
        //Do death things
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("stageHazard"))
        {
            takeDamage(10);
        }
    }
}
