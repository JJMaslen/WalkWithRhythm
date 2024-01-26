using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metronomeScript : MonoBehaviour
{

    public int bpm = 0;
    float timer = 0;

    float bpmConvert()
    {
        float number;

        number = 0;

        return number;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer++;

        if (timer % 50 == 0 )
        {
            Debug.Log(timer.ToString());
        }
    }
}
