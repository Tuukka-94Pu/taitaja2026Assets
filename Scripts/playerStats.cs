using Unity.VisualScripting;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    public int health;

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
        print("You die");
        var death = GameObject.Find("GameManager").GetComponent<GameManager>();
        death.OnDeath();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("stageHazard"))
        {
            takeDamage(10);
        }
    }
}
