using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
class Line
{
    [Serializable]
    public enum CharacterName
    {
        Player, Nathan
    }
    
    public CharacterName character;
    [TextArea] public string text;
}
