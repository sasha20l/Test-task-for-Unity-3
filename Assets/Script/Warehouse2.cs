using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warehouse2 : MonoBehaviour
{
    // Start is called before the first frame update

    public Resourses[] inventory = new Resourses[12];
    private Transform[] children;

    public int redRes;
    public int greenRes;
    public int blueRes;


    public GameObject redToGreen;
    public GameObject redToBlue;
    public GameObject greenToBlue;

    public Transform redToGreenPosition;
    public Transform redToBluePosition;
    public Transform greenToBluePosition;


    void Start()
    {
        children = gameObject.GetComponentsInChildren<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        var red = 0;
        var green = 0;
        var blue = 0;

        for (int i = 0; i < 12; i++)
        {
            if (inventory[i] == null) continue;
            else if (inventory[i].color == Color.red) red++;
            else if (inventory[i].color == Color.green) green++;
            else if (inventory[i].color == Color.blue) blue++;
        }
        redRes = red;
        greenRes = green;
        blueRes = blue;

    }

    public bool AddToWarehouse(Color color)
    {
        for (int i = 0; i < 12; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = new Resourses();
                inventory[i].color = color;
                MeshRenderer[] marr = children[i + 2].GetComponentsInChildren<MeshRenderer>(true);
                foreach (MeshRenderer m in marr)
                {
                    m.enabled = true;
                }
                children[i + 2].GetComponent<Renderer>().material.color = inventory[i].color;
                return true;
            }
        }
        return false;
    }
    public void SendingResource(Color color)
    {
        for (int i = 0; i < 12; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i].color == color)
                {
                    inventory[i] = null;
                    MeshRenderer[] marr = children[i + 2].GetComponentsInChildren<MeshRenderer>(true);
                    foreach (MeshRenderer m in marr)
                    {
                        m.enabled = false;

                    }
                    var res = Instantiate(redToGreen, redToGreenPosition.position, Quaternion.identity);
                    res.GetComponent<Renderer>().material.color = color;
                    break;
                }   
            }
        }
    }
    public void SendingResourceToBlue(Color color)
    {
        for (int i = 0; i < 12; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i].color == color)
                {
                    inventory[i] = null;
                    MeshRenderer[] marr = children[i + 2].GetComponentsInChildren<MeshRenderer>(true);
                    foreach (MeshRenderer m in marr)
                    {
                        m.enabled = false;

                    }
                    if (color == Color.red)
                    {
                        var resRed = Instantiate(redToBlue, redToBluePosition.position, Quaternion.identity);
                        resRed.GetComponent<Renderer>().material.color = color;
                    }
                    else if (color == Color.green)
                    {
                        var resGreen = Instantiate(greenToBlue, greenToBluePosition.position, Quaternion.identity);
                        resGreen.GetComponent<Renderer>().material.color = color;
                    }
                    break;
                }
            }
        }
    }
    public class Resourses
    {
        public Color color;

    }
}