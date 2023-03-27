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
        Отто, Nathan, MiniNathan, Щупальце
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
