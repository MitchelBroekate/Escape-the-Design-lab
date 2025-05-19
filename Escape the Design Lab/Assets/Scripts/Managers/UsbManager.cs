using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsbManager : MonoBehaviour
{
    [SerializeField]
    List<Transform> usbSpawnpoints = new();

    [SerializeField]
    List<GameObject> usbObject = new();

    [System.Obsolete]
    void Start()
    {
        //Spawns the USB sticks in a random set location.
        foreach (GameObject usb in usbObject)
        {
            int randomSpawnpoint = Random.RandomRange(0, usbSpawnpoints.Count);

            Instantiate(usb, usbSpawnpoints[randomSpawnpoint]);
            usbSpawnpoints.Remove(usbSpawnpoints[randomSpawnpoint]);
        }
    }

}
