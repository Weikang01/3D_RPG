using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] dialogue;
    public string Name;

    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, Name);
    }
}
