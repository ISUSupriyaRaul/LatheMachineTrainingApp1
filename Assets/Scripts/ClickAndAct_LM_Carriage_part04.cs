using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// On hover, carriage changes color
/// On mouse click, carriage starts a ping pong movement along the cylinder (fourth instruction)
/// </summary>
public class ClickAndAct_LM_Carriage_part04 : MonoBehaviour
{
    #region Member variables
    [Header("Text Settings")]
    public TMP_Text textTMP;

    private Vector3 originalPosition;
    [Header("Movement Settings")]
    [SerializeField]
    private Vector3 destination = new Vector3(-0.017f, 0.08405223f, 0.8658018f);
    [SerializeField]
    private float speed = 1f; 
    #endregion

    #region Unity event functions
    private void Start()
    {
        originalPosition = transform.localPosition;
    }
    void OnMouseDown()
    {
        textTMP.text = "5. To stop - click on headstock"; // next task to perform
        StartCoroutine("PingPong");
    }
    #endregion

    #region Coroutines
    private IEnumerator PingPong()
    {

        while (true)
        {
            transform.localPosition = Vector3.Lerp(originalPosition, destination, Mathf.PingPong(Time.time * speed, 1.0f));
            yield return new WaitForSeconds(0.01f);
        }
    } 
    #endregion

    #region Custom functions
    public void stopRun()
    {
        StopCoroutine("PingPong");
    } 
    #endregion
}
