using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AiCodePiece : MonoBehaviour
{
    [SerializeField]
    TMP_Text codeText;
    void Start()
    {
        codeText.text = GetRandomLetter().ToString();
    }
    
    Char GetRandomLetter()
    {
        // Random uppercase letter from A (65) to Z (90)
        return (char)UnityEngine.Random.Range(65, 91);
    }
}
