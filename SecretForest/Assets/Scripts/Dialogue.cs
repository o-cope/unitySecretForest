using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{

    [Header("Name")]
    public string name;

    [Header("Sentence")]
    [TextArea(3,10)]
    public string[] sentences;
}
