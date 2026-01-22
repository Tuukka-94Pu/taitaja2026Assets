using System.Collections.Generic;
using Unity.Multiplayer.Center.Common.Analytics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{

    private Dictionary <string , Sprite> inventoryContents = new Dictionary <string , Sprite>();
    private string interaction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Replace with different code if needed!!
        if(Input.GetKeyDown(KeyCode.E))
        {
            useCase(interaction);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pickup"))
        {
            if (inventoryContents.Count < 1)
            {

                var itemName = collision.gameObject.GetComponent<item_data>().item_name;
                var icon = collision.gameObject.GetComponent<item_data>().item_texture;

                    inventoryContents.Add(itemName, icon);
                    interaction = interactiontype(itemName);
                    Destroy(collision.gameObject);
                
            }
        }
    }

    private void TEST()
    {

    }

    private string interactiontype(string name)
    {
         //Add cases for all item names
        switch(name)
        {
            default:
                return null;
        }

    }
    private void useCase(string intercation)
    {
        //add methods for all different interaction outcomes
        switch(intercation)
        {
           
             default :
                TEST();
                break;


        }
    }

}
