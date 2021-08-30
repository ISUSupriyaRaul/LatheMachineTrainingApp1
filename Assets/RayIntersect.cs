using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayIntersect : MonoBehaviour
{

    Material original;
    Renderer renderer;    

    // Start is called before the first frame update
    void Start()
    {
        this.original = null;
        this.renderer = null;
    }

    // Update is called once per frame
    void Update()
    {

        //Plane p = new Plane(Camera.main.transform.forward, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            // Debug.Log("output");



            if (Physics.Raycast(ray, out hit, 100))
            {
                // Debug.Log("hit");//, hit.collider.gameObject.name);
                Debug.Log(hit.collider.gameObject.name);
                //Choose one of them below!!!

                var newhit = hit.collider.gameObject.GetComponent<Renderer>();

                if (this.original == null)
                {
                    this.renderer = newhit;
                    this.original = renderer.material;
                    this.renderer.material.SetColor("_Color", Color.red);
                }
                else {
                    this.renderer.material = this.original;

                    this.renderer = newhit;
                    this.original = renderer.material;
                    this.renderer.material.SetColor("_Color", Color.red);

                }
                /// Name Comparison
                //  if (hit.collider.gameObject.name.equals("NameOfTheObject"))
                //  {
                ///Do Logic
                //  }

                //Tag Comparison
                //  if (hit.collider.gameObject.CompareTag("TagOfTheObject"))
                //  {
                ///Do Logic
                //   }
            }
        }
        else 
        {
            
        }
    }
}
