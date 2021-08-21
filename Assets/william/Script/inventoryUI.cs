using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryUI : MonoBehaviour
{
    public Item[] Items;
    public GameObject DetailPanel;
    public Image DetailImage;
    public Text DetailText;

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
        CloseDetailPanel();
        if (playerStarterAssetsInputs) {
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

    public void ShowDetailPanel(Item item)
    {
        DetailPanel.SetActive(true);
        DetailImage.sprite = item.m_ItemData.m_DisplayImage;
        DetailImage.SetNativeSize();
        DetailText.text = item.m_ItemData.m_Description;
    }

    public void CloseDetailPanel()
    {
        DetailPanel.SetActive(false);
    }

    void GetItemTempleMessage(string itemName)
    {
        Debug.Log("get itemName = " + itemName);
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i].m_ItemData.m_Name == itemName)
            {
                ShowDetailPanel(Items[i]);
            }
        }
    }
}
