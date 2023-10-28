using UnityEngine;
using System.Collections;

public class Destruction : MonoBehaviour
{
    private float Spacing;

    private GameObject warehouse;
    private Color color;

    private void Start()
    {
        color = gameObject.GetComponent<Renderer>().material.color;
        warehouse = GameObject.FindGameObjectWithTag("warehouse");
    }

    void Update()
    {
        Spacing = Vector3.Distance(warehouse.transform.position, gameObject.transform.position);
        Length();
    }
    void Length()
    {
        if (Spacing <= 5.0)
        {
            warehouse.GetComponent<Warehouse1>().AddToWarehouse(color);
            Destroy(gameObject);
        }
    }
}
