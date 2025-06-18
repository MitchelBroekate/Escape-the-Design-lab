using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CodeBehaviour : MonoBehaviour
{
    XRGrabInteractable xRGrabInteractable;
    BoxCollider objectCollider;
    int layerToRemove;

    [SerializeField]
    TMP_Text hexacodeText;
    string hexacode;

    [Header("Audio")]
    AudioSource hexaBordSource;
    public AudioClip[] hexaBordSounds;

    void Start()
    {
        xRGrabInteractable = GetComponent<XRGrabInteractable>();
        objectCollider = GetComponent<BoxCollider>();

        layerToRemove = LayerMask.NameToLayer("Walls");

        hexaBordSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Ground collsision check to despawn code piece
        if (!xRGrabInteractable.isSelected)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                Destroy(gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        //Layer exclude so object doesnt stick in the wall when grabbed
        if (xRGrabInteractable.isSelected)
        {
            objectCollider.excludeLayers = LayerMask.GetMask("Default");
        }
        else
        {
            objectCollider.excludeLayers = 0;
        }
    }

    public TMP_Text HexacodeText
    {
        get { return hexacodeText; }
        set { hexacodeText = value; }
    }

    public string Hexacode
    {
        get { return hexacode; }
        set { hexacode = value; }
    }

    public void GrabSound()
    {
        hexaBordSource.clip = hexaBordSounds[0];
        hexaBordSource.Play();
    }
    public void DropSound()
    {
        hexaBordSource.clip = hexaBordSounds[1];
        hexaBordSource.Play();
    }
}
