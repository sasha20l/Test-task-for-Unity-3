using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateResRedBuilding : MonoBehaviour
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


    void Start()
    {
        ObjectInspector = GameObject.FindGameObjectWithTag("ins");
        InspectorScript = ObjectInspector.GetComponent<Inspector>();
        StartCoroutine("instanti");
    }


    IEnumerator instanti()
    {
        yield return new WaitForSeconds(START);


        while (true)
        {
                if (InspectorScript.warehouseOverflow1 == false)
                {
                    var pref = Instantiate(prefab, transform.position, transform.rotation);
                    pref.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
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
}
