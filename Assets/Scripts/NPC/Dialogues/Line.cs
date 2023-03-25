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
        Player, Nathan, MiniNathan
    }

    /*public override string ToString()
    {
        return character switch
        {
            CharacterName.МиниНатан => "Мини Натан",
            _ => base.ToString()
        };
    }*/

    public CharacterName character;
    [TextArea] public string text;
}
