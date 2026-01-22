using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{

    private Dictionary <string , Sprite> inventoryContents = new Dictionary <string , Sprite>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Replace with different code if needed!!

        if (Input.GetKeyDown(KeyCode.M))
        {
            if(inventoryContents.ContainsKey("heart"))
            {
                Debug.Log("Heart used");
                inventoryContents.Remove("heart");
            }
            else
            {
                Debug.Log("nO heartsh");
            }
        }
        if(Input.GetKeyDown(KeyCode.E))
           {
            foreach (string key in inventoryContents.Keys)
            {
                Debug.Log(key);
            }
           }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pickup"))
        {
            if (inventoryContents.Count < 3)
            {

                var itemName = collision.gameObject.GetComponent<item_data>().item_name;
                var icon = collision.gameObject.GetComponent<item_data>().item_texture;

                if (inventoryContents.ContainsKey(itemName))
                {
                    Debug.Log("cAN'T pickup");
                }
                else
                {
                    inventoryContents.Add(itemName, icon);
                    Destroy(collision.gameObject);
                }
            }
        }
    }

}
