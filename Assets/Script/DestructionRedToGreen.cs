using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionRedToGreen : MonoBehaviour
{
    private float Spacing;

    private GameObject greenBuilding;
    private GameObject ObjectInspector;
    private Inspector InspectorScript;
    private Color color;

    private void Start()
    {
        color = gameObject.GetComponent<Renderer>().material.color;
        greenBuilding = GameObject.FindGameObjectWithTag("GreenBuilding");

        ObjectInspector = GameObject.FindGameObjectWithTag("ins");

        InspectorScript = ObjectInspector.GetComponent<Inspector>();
        InspectorScript._textGreen.text = "";
    }

    void Update()
    {
        Spacing = Vector3.Distance(greenBuilding.transform.position, gameObject.transform.position);
        Length();
    }
    void Length()
    {
        if (Spacing <= 5.0)
        {
            greenBuilding.GetComponent<CreateResGreenBuilding>().Create();
            InspectorScript._textGreen.text = "Не хватает ресурсов для производства зеленого куба!";
            Destroy(gameObject);
        }
    }
}
