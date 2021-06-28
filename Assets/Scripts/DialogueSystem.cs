using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance { get; set; }
    public GameObject dialoguePanel;
    public string npcName;
    public List<string> dialogueLines = new List<string>();

    Button continueButton;
    Text dialogueText, nameText;
    int dialogueIndex;
    private void Awake()
    {
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("DialogueText").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").Find("NameText").GetComponent<Text>();
        dialoguePanel.SetActive(false);

        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddNewDialogue(string line, string npcName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>();
        dialogueLines.Add(line);
        this.npcName = npcName;

        CreateDialogue();
    }

    public void AddNewDialogue(string[] lines, string npcName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>();
        dialogueLines.AddRange(lines);
        this.npcName = npcName;

        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[0];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);

    }

    public void ContinueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
