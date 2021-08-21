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

    public void SetData(Sprite sp, string description, string orderData)
    {
        //if (image.sprite) image.sprite = sp ? sp : null;
        text.text = description;
        order = orderData;
    }
}
