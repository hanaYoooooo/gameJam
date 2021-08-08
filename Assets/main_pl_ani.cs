using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_pl_ani : MonoBehaviour
{
    public float ani_time=3.5f;
    Animation ani;
    void Start()
    {
        ani= this.gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        ani_time -= Time.deltaTime;
        if (ani_time == 0.0f)
        {
            ani_time = -0.2f;
            ani.Play();
        }
    }
}
