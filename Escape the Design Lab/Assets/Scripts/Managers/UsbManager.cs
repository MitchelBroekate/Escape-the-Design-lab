using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsbManager : MonoBehaviour
{
    [SerializeField]
    List<Transform> usbSpawnpoints = new();

    [SerializeField]
    List<GameObject> usb = new();
}
