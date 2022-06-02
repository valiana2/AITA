using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue //class which allows to have a NPC name and a nice area for dialogues
{
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;

}
