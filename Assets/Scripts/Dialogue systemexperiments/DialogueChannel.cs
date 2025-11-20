using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueChannel", menuName = "Scriptable Objects/Narration/Dialogue/DialogueChannel")]
public class DialogueChannel : ScriptableObject
{
    public delegate void DialogueCallback (Dialogue dialogue);
    public DialogueCallback OnDialogueRequested;
    public DialogueCallback OnDialogueStart;
    public DialogueCallback OnDialogueEnd;

    public delegate void DialogueNodeCallback(DialogueNode node);
    public DialogueNodeCallback OnDialogueNodeRequestedl;
    public DialogueNodeCallback OnDialogueNodeStart;
    public DialogueNodeCallback OnDialogueNodeEnd;

    public void RaiseRequestedDialogue (Dialogue dialogue)
    {
        OnDialogueRequested?.Invoke (dialogue);
    }
    public void RaiseDialogueStart (Dialogue dialogue)
    {
        OnDialogueStart?.Invoke (dialogue);
    }
}
