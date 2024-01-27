using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class metronomeScript : MonoBehaviour
{

    [SerializeField] int bpm = 60;
    [SerializeField] int timer = 0;
    [SerializeField] int difficulty = 0;

    [SerializeField] double tbb;
    
    [SerializeField] GameObject character = null;
    

    public static bool OnBeat = false;
    
    double bpmConvert(double bpm)
    {
        tbb = 60 / bpm;
        return tbb;
    }

    void characterAnimate(bool on)
    {
        if (on) 
        {
            character.transform.localScale = new Vector3(1, 0.6f, 1);
        }
        else
        {
            character.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer++;
        int beat = (int)(bpmConvert(bpm) * 50);

        int count = timer % beat;

        if (count >= beat - difficulty)
        {
            if (OnBeat == false)
            {
                OnBeat = true;
                characterAnimate(true);
            }
            OnBeat = true;
        }
        else if (count <= difficulty)
        {
            OnBeat = true;
        }
        else
        {
            OnBeat = false;
            characterAnimate(false);
        }
    }
}
