using StarterAssets;
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
    private StarterAssetsInputs playerStarterAssetsInputs;
    private FirstPersonController firstPersonController;
    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    private void init()
    {
        GameObject player = GameObject.Find("PlayerCapsule");
        if (player)
        {
            playerStarterAssetsInputs = player.GetComponent<StarterAssets.StarterAssetsInputs>();
            firstPersonController = player.GetComponent<StarterAssets.FirstPersonController>();
        }
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
        if (playerStarterAssetsInputs)
        {
            playerStarterAssetsInputs.SetCursorInputForLook(false);
            playerStarterAssetsInputs.SetCursorLocked(false);
            firstPersonController.enabled = false;
        }
        else
        {
            init();
            playerStarterAssetsInputs.SetCursorInputForLook(false);
            playerStarterAssetsInputs.SetCursorLocked(false);
            firstPersonController.enabled = false;
        }
    }

    private void OnDisable()
    {
        if (playerStarterAssetsInputs)
        {
            playerStarterAssetsInputs.SetCursorInputForLook(true);
            playerStarterAssetsInputs.SetCursorLocked(true);
            firstPersonController.enabled = true;
        }
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
            //TODO: 撥放真結局
            Debug.Log("答對 ");
        }
        else
        {
            //TODO: 撥放失敗結局
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
        checkResult[result - 1] = item.SourceObject.GetComponent<SortGameElement>().order;
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
