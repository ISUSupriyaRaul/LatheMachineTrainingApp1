using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickAndAct01 : MonoBehaviour
{
    public TMP_Text textTMP;

    public GameObject object03;
    public GameObject object04;
    public GameObject object05;

    void OnMouseDown()
    {
        textTMP.text = "1. Clamp metal rod into spindle"; // next task to perform

        object03.GetComponent<ClickAndAct03>().stopRun();
        object04.GetComponent<ClickAndAct04>().stopRun();
        object05.GetComponent<ClickAndAct05>().stopRun();
    }

}
