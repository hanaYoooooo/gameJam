using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public Item[] Items;
    public string nextScene = "main";
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].m_ItemData.m_HasGotten = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Single);
    }
}
