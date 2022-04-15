using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueScriptableTemplate : ScriptableObject
{
    public string dialogue;
    public string character;
    public string language;
    public AudioClip dialogueSound;
}
