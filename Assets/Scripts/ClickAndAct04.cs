using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickAndAct04 : MonoBehaviour
{
    public TMP_Text textTMP;

    Vector3 originalPosition;
    public Vector3 destination = new Vector3(-0.017f, 0.08405223f, 0.8658018f);
    public float speed = 1f;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }
    void OnMouseDown()
    {
        textTMP.text = "5. To stop - click on headstock"; // next task to perform
        StartCoroutine("PingPong");
    }

    IEnumerator PingPong()
    {

        while (true)
        {
            transform.localPosition = Vector3.Lerp(originalPosition, destination, Mathf.PingPong(Time.time * speed, 1.0f));
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void stopRun()
    {
        StopCoroutine("PingPong");
    }
}
