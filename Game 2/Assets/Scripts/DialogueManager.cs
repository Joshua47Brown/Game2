using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;

    public bool dialogueActive;

    public string[] dialogueLines;
    public int currentLine;
    public bool canDialogueShow;

	void Start()
    {
        canDialogueShow = true;
    }


    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.J))
        {
            currentLine++;
        }
        if (currentLine >= dialogueLines.Length)
        {
            dBox.SetActive(false);
            dialogueActive = false;
            canDialogueShow = false;
            StartCoroutine(DialogueDelay());
            currentLine = 0;
        }

        dText.text = dialogueLines[currentLine];
    }


    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogueActive = true;
        dBox.SetActive(true);
    }

    public IEnumerator DialogueDelay()
    {
        yield return new WaitForSeconds(1);
        canDialogueShow = true;
    }
}
