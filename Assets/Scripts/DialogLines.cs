using TMPro;
using UnityEngine;

public class DialogLines : MonoBehaviour
{

    [SerializeField] TMP_Text dialogueText;
    [SerializeField] string[] timelineTextlines; 
    int currentLine = 0;

    public void NextDialogLine()
    {
        currentLine++;
        dialogueText.text = timelineTextlines[currentLine];
    }
}

