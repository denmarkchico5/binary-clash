using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ResetPattern : MonoBehaviour
{
    MainGameLogic resetPattern;
   // MainGameLogic destroyPattern;
    public void reset() 
    {
        resetPattern = FindObjectOfType<MainGameLogic>();
        resetPattern.displayPattern();
        resetPattern.displayTextPattern();
       // Debug.Log("RESET PATTERN");
    }
}
