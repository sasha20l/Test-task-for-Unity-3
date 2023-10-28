using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inspector : MonoBehaviour
{
    [SerializeField] public Text _textRed;
    [SerializeField] public Text _textGreen;
    [SerializeField] public Text _textBlue;

    public bool warehouseOverflow1 = false;
    public bool warehouseOverflow2 = false;

    Warehouse1 Warehouse1Script;
    Warehouse2 Warehouse2Script;
    // Start is called before the first frame update
    void Start()
    {
        Warehouse1Script = GameObject.FindGameObjectWithTag("warehouse").GetComponent<Warehouse1>();
        Warehouse2Script = GameObject.FindGameObjectWithTag("warehouse2").GetComponent<Warehouse2>();
        _textRed.text = $"";
        _textGreen.text = $"�� ������� �������� ��� ������������ �������� ����!";
        _textBlue.text = $"�� ������� �������� ��� ������������ ������ ����!";
    }

    // Update is called once per frame
    void Update()
    {
         warehouseOverflow1 = overflowCheck(Warehouse1Script.inventory);
         warehouseOverflow2 = overflowCheck(Warehouse2Script.inventory);

        if (warehouseOverflow1 == true)
        {
            _textRed.text = $"������������ � ������� ���� ������������! ����� ����������.";
            _textGreen.text = $"������������ � ������� ���� ������������! ����� ����������.";
            _textBlue.text = $"������������ � ����� ���� ������������! ����� ����������.";
        }
    }

    bool overflowCheck(object[] mass)
    {
        foreach (var i in mass)
        {
            if (i == null) return false; 
        }
        return true;
    }
}
