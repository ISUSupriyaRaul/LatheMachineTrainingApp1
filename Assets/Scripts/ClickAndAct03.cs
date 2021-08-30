using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class ClickAndAct03 : MonoBehaviour
{
    public TMP_Text textTMP;

    public GameObject cylinder;
    private bool cylinderActive = false;
    public float speed = 100f;
    private int clicks = 0;

    void OnMouseDown()
    {
        clicks += 1;

        //Debug.Log(clicks + "  " + cylinderActive);

        if (cylinder != null)
        {
            cylinder.SetActive(true);
            cylinderActive = true;
            textTMP.text = "2. Adjust tailstock to fix metal rod"; // next task to perform
        }

        if (cylinderActive == true && clicks==2)
        {
            textTMP.text = "4. Use toolpost to do your job"; // next task to perform
            StartCoroutine("Rotate");
        }
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            // rotate the GameObject in the local space and relative to axes of iteself
            transform.Rotate(0.0f, 0.0f, speed * Time.deltaTime, Space.Self);
            cylinder.transform.Rotate(0.0f, -speed * Time.deltaTime, 0.0f, Space.Self);

            yield return new WaitForSeconds(0.01f);
        }

    }

    public void stopRun()
    {
        StopCoroutine("Rotate");
        cylinder.SetActive(false);
        clicks = 0;
    }
}
