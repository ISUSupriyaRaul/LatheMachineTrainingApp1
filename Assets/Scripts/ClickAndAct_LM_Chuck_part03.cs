using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

/// <summary>
/// On hover, chuck/spindle changes color
/// On first mouse click, a cylinder gets placed close to it (first instruction)
/// On second mouse click, chuck starts to rotate and also the cylinder (third instruction)
/// </summary>
public class ClickAndAct_LM_Chuck_part03 : MonoBehaviour
{

    #region Member variables
    [Header("Text Settings")]
    public TMP_Text textTMP;

    public GameObject cylinder;
    [Header("Movement Settings")]
    [SerializeField]
    private bool cylinderActive = false;
    [SerializeField]
    private float speed = 100f;
    private int clicks = 0;
    #endregion

    #region Properties

    public bool CyclinderActive
    {
        get
        {
            return this.cylinderActive;
        }
        set
        {
            this.cylinderActive = value;
        }
    } 
    #endregion


    #region Unity event functions
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

        if (cylinderActive == true && clicks == 2)
        {
            textTMP.text = "4. Use toolpost to do your job"; // next task to perform
            StartCoroutine("Rotate");
        }
    }
    #endregion

    #region Coroutines
    private IEnumerator Rotate()
    {
        while (true)
        {
            // rotate the GameObject in the local space and relative to axes of iteself
            transform.Rotate(0.0f, 0.0f, speed * Time.deltaTime, Space.Self);
            cylinder.transform.Rotate(0.0f, -speed * Time.deltaTime, 0.0f, Space.Self);

            yield return new WaitForSeconds(0.01f);
        }

    }
    #endregion

    #region Custom functions
    public void stopRun()
    {
        StopCoroutine("Rotate");
        cylinder.SetActive(false);
        clicks = 0;
    } 
    #endregion
}
