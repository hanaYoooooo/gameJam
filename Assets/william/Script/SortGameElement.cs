using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortGameElement : MonoBehaviour
{
    public Image image;
    public Text text;
    public string order;
    public bool canGrabbed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetData(Sprite sp,string name, string orderData)
    {
        image.sprite = sp;
        text.text = name;
        order = orderData;
    }
}
