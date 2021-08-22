using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeItem : MonoBehaviour
{
    public Item item;

    private IncrementOnDestroy incrementOnDestroy;
    // Start is called before the first frame update
    void Start()
    {
        if (item.m_ItemData.m_HasGotten)
        {
            GetComponent<IncrementOnDestroy>().incrementOn = IncrementOnDestroy.IncrementOn.Manually;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
