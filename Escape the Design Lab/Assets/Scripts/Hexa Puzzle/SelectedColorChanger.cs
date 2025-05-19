using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedColorChanger : MonoBehaviour
{
    string currentCode;
    
    [SerializeField]
    Image currentHexColorVisual, wrongColor;

    
    [SerializeField]
    TMP_Text hexcode;

    [SerializeField]
    GameObject ParentLogo;
    [SerializeField]
    GameObject ParentAiCode;
    [SerializeField]
    TMP_Text aiCodeText;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CodePiece")
        {
            currentCode = other.GetComponent<CodeBehaviour>().Hexacode;

            if (currentCode == null) return;

            hexcode.text = currentCode;

            ColorUtility.TryParseHtmlString("#" + currentCode, out Color correctColorHex);

            currentHexColorVisual.color = correctColorHex;

            Destroy(other.gameObject);
        }
    }

    public void ConfirmColor()
    {
        if(currentCode == null) return;

        //change wrong color
        ColorUtility.TryParseHtmlString("#" + currentCode, out Color correctColorHex);
        wrongColor.color = correctColorHex;

        if (currentCode == "FA6805")
        {
            //feedback right code

            ParentAiCode.SetActive(true);
            aiCodeText.text = GetRandomLetter().ToString();
            ParentLogo.SetActive(false);
        }
        else
        {
            //feedback wrong code
            
            Debug.Log("Wrong Code");
        }
    }

    char GetRandomLetter()
    {
        // Random uppercase letter from A (65) to Z (90)
        return (char)Random.Range(65, 91);
    }
}