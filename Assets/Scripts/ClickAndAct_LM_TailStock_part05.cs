using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// On hover, tailstock changes color
/// On mouse click, tailstock moves and supports the cylinder from the other end (second instruction)
/// </summary>

public class ClickAndAct_LM_TailStock_part05 : MonoBehaviour
{
    #region Member variables
    [Header("Text Settings")]
    public TMP_Text textTMP;

    
    private Vector3 originalPosition;
    [Header("Movement Settings")]
    [SerializeField]
    private Vector3 destination = new Vector3(-0.3428f, 0.084f, 0.978f);
    [SerializeField]
    private float totalMovementTime = 5f; //the amount of time the movement should take 
    #endregion


    #region  Unity event functions
    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void OnMouseDown()
    {
        textTMP.text = "3. Turn on spindle"; // next task to perform
        StartCoroutine("Move");
    }

    #endregion

    #region Coroutines
    private IEnumerator Move()
    {
        float currentMovementTime = 0f; //The amount of time that has passed

        while (Vector3.Distance(transform.localPosition, destination) > 0)
        {
            currentMovementTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(transform.localPosition, destination, currentMovementTime / totalMovementTime);
            yield return null;
        } 
    }
    #endregion

    #region custom functions
    public void stopRun()
    {
        StopCoroutine("Move");
        transform.localPosition = originalPosition;
    } 
    #endregion
}
