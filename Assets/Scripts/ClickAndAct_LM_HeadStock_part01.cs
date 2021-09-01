using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Reset the lathe machine to intial position when user clicks on this part i.e. headstock
/// Also reset the instruction text to the first instruction
/// </summary>

public class ClickAndAct_LM_HeadStock_part01 : MonoBehaviour
{
    #region Member variables
    [Header("Reset Settings")]
    public TMP_Text textTMP;
    public GameObject[] PartsToReset;

    private ClickAndAct_LM_Chuck_part03 chuckScript; //script on LM_Chuck_part03
    private ClickAndAct_LM_Carriage_part04 carriageScript; //script on LM_Carriage_part04
    private ClickAndAct_LM_TailStock_part05 tailStockScript; //script on LM_TailStock_part05 
    #endregion


    #region Unity event functions
    private void Start()
    {

        // fetch scripts to stop execution
        chuckScript = PartsToReset[0].GetComponent<ClickAndAct_LM_Chuck_part03>();
        carriageScript = PartsToReset[1].GetComponent<ClickAndAct_LM_Carriage_part04>();
        tailStockScript = PartsToReset[2].GetComponent<ClickAndAct_LM_TailStock_part05>();
    }

    void OnMouseDown()
    {   
        // stop parts' movement and reset text on mouse click
        textTMP.text = "1. Clamp metal rod into spindle"; // reset instructions // first task to perform
        chuckScript.CyclinderActive = false;
        chuckScript.stopRun();
        carriageScript.stopRun();
        tailStockScript.stopRun();
    } 
    #endregion

}
