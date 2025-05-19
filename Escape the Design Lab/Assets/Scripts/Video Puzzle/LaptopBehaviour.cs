using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LaptopBehaviour : MonoBehaviour
{
    //Laptop screen tells the player to find USB
    [SerializeField]
    TMP_Text laptopHintText;

    int collectedUsb;

    void Start()
    {
        laptopHintText.text = "Find 3 USB Sticks";
    }

    void OTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Usb")
        {
            UsbDetection();
        }
    }

    void UsbDetection()
    {
        collectedUsb++;
    }

    //Laptop needs to detect a held USB, despawn held USB, and show USB in laptop +1.


    //If laptop has all USB, the Screen should tell the player to edit the clips
}