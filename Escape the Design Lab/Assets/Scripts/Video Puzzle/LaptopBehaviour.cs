using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LaptopBehaviour : MonoBehaviour
{
    //Laptop screen tells the player to find USB
    [SerializeField]
    TMP_Text laptopHintText;

    [SerializeField]
    List<GameObject> usbInLaptop = new();

    int collectedUsb = 3;

    void Start()
    {
        laptopHintText.text = "Find " + collectedUsb + " USB Sticks";
    }

    //Laptop needs to detect a held USB, despawn held USB, and show USB in laptop +1.
    void OTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Usb")
        {
            UsbDetection();
            Destroy(other.gameObject);
        }
    }

    void UsbDetection()
    {
        collectedUsb--;

        laptopHintText.text = "Find " + collectedUsb + " USB Sticks";
        
        usbInLaptop[collectedUsb].SetActive(true);
    }



    //If laptop has all USB, the Screen should tell the player to edit the clips
}