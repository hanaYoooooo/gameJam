using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public IncrementOnDestroy[] incrementOnDestroys;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Reload()
    {
        Debug.Log("Reload");
        foreach(var go in incrementOnDestroys)
        {
            go.incrementOn = IncrementOnDestroy.IncrementOn.Manually;
        }
    }
}
