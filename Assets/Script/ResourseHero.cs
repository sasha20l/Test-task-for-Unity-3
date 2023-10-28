using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourseHero : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform[] children;
    public Resourse[] inventory = new Resourse[4];
    void Start()
    {

         children = gameObject.GetComponentsInChildren<Transform>();

        NoActiveResourse();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool PutInventory(Color col)
    {

        if (inventory[3] != null) return false;
        else if (inventory[2] != null)
        {
            inventory[3] = inventory[2];
            inventory[2] = inventory[1];
            inventory[1] = inventory[0];
            inventory[0] = new Resourse();
            inventory[0].color = col;
            ActiveResourse();

        }
        else if (inventory[1] != null)
        {
            inventory[2] = inventory[1];
            inventory[1] = inventory[0];
            inventory[0] = new Resourse();
            inventory[0].color = col;
            ActiveResourse();
        }
        else if (inventory[0] != null)
        {
            inventory[1] = inventory[0];
            inventory[0] = new Resourse();
            inventory[0].color = col;
    
            ActiveResourse();
        }
        else
        {
            inventory[0] = new Resourse();
            inventory[0].color = col;

            ActiveResourse();
        }

        return true;
    }
    bool TakeOutInventory(Color col)
    {
        if (inventory == null) return false;
            inventory = null;
            for (int i = 0; i < 4; i++)
            {
                MeshRenderer[] marr = children[i + 2].GetComponentsInChildren<MeshRenderer>(true);
                foreach (MeshRenderer m in marr)
                {
                    m.enabled = false;
                }
            }
        return true;

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
            children[i+1].GetComponent<Renderer>().material.color = inventory[i].color;

        }
    }
    
}

public class Resourse
{
    public Color color;

}
