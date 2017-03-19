using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueContainer : MonoBehaviour {

    public string dialogue;
    DialogueManager dManager;

    public string[] dialogueLines;


    void Start()
    {
        dManager = FindObjectOfType<DialogueManager>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.J) && dManager.canDialogueShow)
            {
                if (!dManager.dialogueActive)
                {
                    dManager.dialogueLines = dialogueLines;
                    dManager.currentLine = 0;
                    dManager.ShowDialogue();
                    dManager.canDialogueShow = false;
                }

                if (transform.parent.GetComponent<NpcBehaviour>() != null)
                {
                    transform.parent.GetComponent<NpcBehaviour>().canMove = false;

                }

            }
        }
    }
}
