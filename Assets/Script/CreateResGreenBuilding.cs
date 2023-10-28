using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateResGreenBuilding : MonoBehaviour
{
    public float Timer = 15f;
    public float START = 5F;
    public GameObject prefab;
    public GameObject spawn;

    private int ciclesToSpeedUp = 2;
    private float speedUpTimerDelta = 2f;
    private float timerMinimum = 4f;
    private int instantiatingCount = 0;
    private GameObject ObjectInspector;
    Inspector InspectorScript;

    private GameObject warehouse2;
    Warehouse2 warehouse2Script;

    public int redResurse;




    void Start()
    {
        ObjectInspector = GameObject.FindGameObjectWithTag("ins");
        InspectorScript = ObjectInspector.GetComponent<Inspector>();

        warehouse2 = GameObject.FindGameObjectWithTag("warehouse2");
        warehouse2Script = warehouse2.GetComponent<Warehouse2>();

        StartCoroutine("instanti");
    }


    IEnumerator instanti()
    {
        yield return new WaitForSeconds(START);


        while (true)
        {
            if (InspectorScript.warehouseOverflow1 == false && resurse() == true)
            {
                warehouse2Script.SendingResource(Color.red);
            }
            ++instantiatingCount;

            if (instantiatingCount == ciclesToSpeedUp)
            {
                if (Timer > timerMinimum)
                    Timer -= speedUpTimerDelta;
            }

            yield return new WaitForSeconds(Timer);

        }
    }

    bool resurse()
    {
        if (warehouse2Script.redRes > 0)
        {
          
            warehouse2Script.redRes--;           
            return true;
        }
        return false;
    }

    public void Create()
    {
        var pref = Instantiate(prefab, transform.position, transform.rotation);
        pref.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
    }
}
