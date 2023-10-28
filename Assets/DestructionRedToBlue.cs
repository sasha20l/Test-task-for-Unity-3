using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionRedToBlue : MonoBehaviour
{
    private float Spacing;

    private GameObject blueBuilding;
    private GameObject ObjectInspector;
    private Inspector InspectorScript;
    private Color color;

    private void Start()
    {
        color = gameObject.GetComponent<Renderer>().material.color;
        blueBuilding = GameObject.FindGameObjectWithTag("BlueBuilding");

        ObjectInspector = GameObject.FindGameObjectWithTag("ins");

        InspectorScript = ObjectInspector.GetComponent<Inspector>();
        InspectorScript._textBlue.text = "";
    }

    void Update()
    {
        if (gameObject.transform.position != null)
        {
            Spacing = Vector3.Distance(blueBuilding.transform.position, gameObject.transform.position);
            Length();

        }
    }
    void Length()
    {
        if (Spacing <= 5.0)
        {
            if (color == Color.green)
            {
                blueBuilding.GetComponent<CreateResBlueBuilding>().Create();
            }
            InspectorScript._textBlue.text = "Ќе хватает ресурсов дл€ производства синего куба!";
            Destroy(gameObject);
        }
    }
}
