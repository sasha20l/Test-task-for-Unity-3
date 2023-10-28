using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warehouse1 : MonoBehaviour
{
    // Start is called before the first frame update

    public Resourses[] inventory = new Resourses[12];
    private Transform[] children;

    [SerializeField] private Text _textRed;
    [SerializeField] private Text _textGreen;
    [SerializeField] private Text _textBlue;


    void Start()
    {
        children = gameObject.GetComponentsInChildren<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        
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
    public bool TakeToWarehouse(ResourseHero scriptResourseHero)
    {

        for (int i = 0; i < 12; i++)
        {
            if (inventory[i] == null) continue;
            if (scriptResourseHero.PutInventory(inventory[i].color) == false)
                {
                    return false;
                }
            
            inventory[i] = null;
            MeshRenderer[] marr = children[i + 2].GetComponentsInChildren<MeshRenderer>(true);
            foreach (MeshRenderer m in marr)
            {
                m.enabled = false;
            }
        }
        return true;
    }
    public class Resourses
    {
        public Color color;

    }
}
