using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public MouseLook cameraMovement;
    public PlayerMovement movement;
    GameObject textBox;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        nameText.text = dialogue.name;

        if (sentences.Count == 0)
        {
            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }
            sentences.Enqueue("End");
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        string sentence = sentences.Dequeue();

        if (sentence == "End")
        {
            EndDialogue();
            return;
        }
        else
        {
            dialogueText.text = sentence;
        }
    }

    void EndDialogue()
    {
        textBox = GameObject.Find("TextBox");
        textBox.SetActive(false);

        cameraMovement.enabled = true;
        movement.enabled = true;
    }
}
