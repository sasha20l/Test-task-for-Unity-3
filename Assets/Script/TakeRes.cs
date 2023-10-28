using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeRes : MonoBehaviour
{
    private float Spacing;
    private float Spacing2;
    private Transform[] children;
    private Resourse[] inventory = new Resourse[4];
    private Warehouse1 scriptWarehouse1;
    private Warehouse2 scriptWarehouse2;
    private ResourseHero scriptResourseHero;

    private GameObject warehouse;
    private GameObject warehouse2;
    // Start is called before the first frame update
    void Start()
    {
        warehouse = GameObject.FindGameObjectWithTag("warehouse");
        warehouse2 = GameObject.FindGameObjectWithTag("warehouse2");
        scriptWarehouse1 = warehouse.GetComponent<Warehouse1>();
        scriptWarehouse2 = warehouse2.GetComponent<Warehouse2>();
        children = gameObject.GetComponentsInChildren<Transform>();
        scriptResourseHero = gameObject.GetComponent<ResourseHero>();
        
    }

    // Update is called once per frame
    void Update()
    {
        inventory = scriptResourseHero.inventory;
        Spacing = Vector3.Distance(warehouse.transform.position, gameObject.transform.position);
        Spacing2 = Vector3.Distance(warehouse2.transform.position, gameObject.transform.position);
        Length();
    }

    void Length()
    {
        if (Spacing <= 5.0)
        {
            for (int i = 0; i < 4; i++)
            {
                if (inventory[i] == null)
                {
                    scriptWarehouse1.TakeToWarehouse(scriptResourseHero);
                }
            }
        }
        else if (Spacing2 <= 5.0)
        {
            for (int i = 0; i < 4; i++)
            {
                if (inventory[i] != null)
                {   
                    scriptWarehouse2.AddToWarehouse(inventory[i].color);
                    inventory[i] = null;
                  
                }
                
            }
            NoActiveResourse();
        }
}
    public void ActiveResourse()
    {

        for (int i = 0; i < 4; i++)
        {
            if (inventory[i] == null) continue;
            MeshRenderer[] marr = children[i + 1].GetComponentsInChildren<MeshRenderer>(true);
            foreach (MeshRenderer m in marr)
            {
                m.enabled = true;
            }
            children[i + 1].GetComponent<Renderer>().material.color = inventory[i].color;

        }
    }
    public void NoActiveResourse()
    {
        for (int i = 0; i < 4; i++)
        {
            MeshRenderer[] marr = children[i + 1].GetComponentsInChildren<MeshRenderer>(true);
            foreach (MeshRenderer m in marr)
            {
                m.enabled = false;
            }
        }

    }
}
