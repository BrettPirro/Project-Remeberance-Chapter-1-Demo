using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TextOBJ : ScriptableObject
{
    [SerializeField] [TextArea] string Text;
   

    public string GetText() 
    {
        return Text;
    }
    



}
