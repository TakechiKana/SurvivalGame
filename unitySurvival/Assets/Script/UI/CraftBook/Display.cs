using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    private GameObject craftBookButton;
    private Item item;
    // Start is called before the first frame update
    void Start()
    {
        craftBookButton = GameObject.Find("CraftBookButton");
        item = craftBookButton.GetComponent<CraftBookButton>().item;
    }

    void DisplayProcess()
    {
        
    }
}
