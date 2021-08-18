using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortGame : MonoBehaviour
{
    public Item[] Items;
    public Transform myItemsRoot;
    public Transform checkItemsRoot;
    public GameObject SortGameElementTemplate;
    public SortGameAnswer sortGameAnswer;

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
                sge.SetData(Items[i].m_ItemData.m_DisplayImage, Items[i].m_ItemData.m_Name, Items[i].m_ItemData.m_Order);
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
        foreach(var go in sortGameElements)
        {
            result += go.order;
        }
        Debug.Log("result = " + result);
        if(string.Equals(result, sortGameAnswer.m_Answer))
        {
            Debug.Log("µª¹ï ");
        }
        else
        {
            Debug.Log("µª¿ù ");
        }
    }
}
