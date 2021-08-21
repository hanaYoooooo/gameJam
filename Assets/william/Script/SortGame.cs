using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Extensions.ReorderableList;

public class SortGame : MonoBehaviour
{
    public Item[] Items;
    public Transform myItemsRoot;
    public Transform checkItemsRoot;
    public GameObject SortGameElementTemplate;
    public SortGameAnswer sortGameAnswer;
    private string[] checkResult = new string[9];

    private List<SortGameElement> sortGameElements = new List<SortGameElement>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i].m_ItemData.m_HasGotten)
            {
                GameObject go = Instantiate(SortGameElementTemplate, myItemsRoot);
                SortGameElement sge = go.GetComponent<SortGameElement>();
                sge.SetData(Items[i].m_ItemData.m_DisplayImage, Items[i].m_ItemData.m_Description, Items[i].m_ItemData.m_Order);
                sortGameElements.Add(sge);
            }
        }
    }

    private void OnDisable()
    {
        
    }

    public void CheckSortGameResult()
    {
        string result = "";
        bool hasEmpty = false;
        foreach (var go in checkResult)
        {
            if (string.IsNullOrEmpty(go))
            {
                hasEmpty = true;
            }
            else
            {
                result += go;
            }
        }
        Debug.Log("result = " + result);
        if(string.Equals(result, sortGameAnswer.m_Answer) && !hasEmpty)
        {
            Debug.Log("答對 ");
        }
        else
        {
            Debug.Log("答錯 或仍有選項未填");
        }
    }

    public void TestReOrderableListTarget(ReorderableListEventStruct item)
    {
        Debug.Log("Event Received");
        Debug.Log("Hello World, is my item a clone? [" + item.IsAClone + "]" + item.FromList.gameObject.name);
    }

    public void AddedReOrderableListTarget(ReorderableListEventStruct item)
    {
        Debug.Log("Hello World, is my item a clone? [" + item.IsAClone + "]" + item.ToList.gameObject.name);
        string sArray = item.ToList.gameObject.name.Substring(4,1);
        int result = Int32.Parse(sArray);
        Debug.Log("index = " + result);
        checkResult[result - 1] = sArray;
    }

    public void RemovedReOrderableListTarget(ReorderableListEventStruct item)
    {
        Debug.Log("Hello World, is my item a clone? [" + item.IsAClone + "]" + item.FromList.gameObject.name);
        string sArray = item.FromList.gameObject.name.Substring(4, 1);
        int result = Int32.Parse(sArray);
        Debug.Log("index = " + result);
        checkResult[result - 1] = string.Empty;
    }
}
