using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Power_UP : MonoBehaviour
{
    float timer = 0;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer < 0.2) 
        {
            gameObject.transform.position += new Vector3(0,0.1f);
        }
    }




}
