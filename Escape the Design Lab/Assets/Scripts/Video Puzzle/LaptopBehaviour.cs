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

    int collectedUsb = 0;
    int usbToCollect = 3;

    [SerializeField] GameObject screenClips, screenText;

    void Start()
    {
        laptopHintText.text = "Vindt " + usbToCollect + " USB Sticks";
    }

    //Laptop needs to detect a held USB, despawn held USB, and show USB in laptop +1.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Usb")
        {
            UsbDetection();
            Destroy(other.gameObject);
        }
    }

    void UsbDetection()
    {
        collectedUsb++;
        usbToCollect--;

        if (collectedUsb >= 3)
        {
            usbInLaptop[usbToCollect].SetActive(true);

            laptopHintText.text = "Edit de video clips";

            //set clips true

            screenClips.SetActive(true);
            screenText.SetActive(true);
        }
        else
        {
            laptopHintText.text = "Vindt " + usbToCollect + " USB Sticks";

            usbInLaptop[usbToCollect].SetActive(true);
        }


    }

    //If laptop has all USB, the Screen should tell the player to edit the clips
}