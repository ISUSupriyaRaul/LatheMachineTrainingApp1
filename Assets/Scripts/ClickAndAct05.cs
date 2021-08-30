using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class ClickAndAct05 : MonoBehaviour
{
    public TMP_Text textTMP;
    Vector3 originalPosition;
    public Vector3 destination = new Vector3(-0.3428f, 0.084f, 0.978f);
    public float totalMovementTime = 5f; //the amount of time the movement should take

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    void OnMouseDown()
    {
        textTMP.text = "3. Turn on spindle"; // next task to perform
        StartCoroutine("Move");
    }

    IEnumerator Move()
    {
        float currentMovementTime = 0f; //The amount of time that has passed

        while (Vector3.Distance(transform.localPosition, destination) > 0)
        {
            currentMovementTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(transform.localPosition, destination, currentMovementTime / totalMovementTime);
            yield return null;
        }

    }

    public void stopRun()
    {
        StopCoroutine("Move");
        transform.localPosition = originalPosition;
    }
}
