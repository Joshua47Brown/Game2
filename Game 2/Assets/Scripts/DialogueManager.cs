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

	void Start()
    {
        //InvokeRepeating("ExitDialogue", 0.1f, 60.0f);
    }


    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.J))
        {
            currentLine++;
            //dBox.SetActive(false);
            //dialogueActive = false;
        }
        if (currentLine >= dialogueLines.Length)
        {
            dBox.SetActive(false);
            dialogueActive = false;

            currentLine = 0;
        }

        dText.text = dialogueLines[currentLine];
    }


    //void ExitDialogue()
    //{
    //    if (dialogueActive && Input.GetKeyUp(KeyCode.J))
    //    {
    //        dBox.SetActive(false);
    //        dialogueActive = false;
    //        CancelInvoke("ExitDialogue");
    //    }
    //}

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
}
