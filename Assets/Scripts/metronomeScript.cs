using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class metronomeScript : MonoBehaviour
{

    public int bpm = 60;
    [SerializeField] int timer = 0;
    [SerializeField] int difficulty = 0;

    [SerializeField] double tbb;
    
    [SerializeField] GameObject character = null;
    

    public bool OnBeat = false;
    bool doingAnimation = false;

    public double bpmConvert(double bpm)
    {
        tbb = 60 / bpm;
        return tbb;
    }

    IEnumerator characterAnimate(float time, float duration)
    {
        float lerp;
        while (time < duration)
        {
            lerp = Mathf.Lerp(0.6f, 1, time/duration);
            character.transform.localScale = new Vector3(character.transform.localScale.x, lerp, character.transform.localScale.z);
            Debug.Log(lerp);
            time += Time.deltaTime;
            yield return null;
        }
        doingAnimation = false;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (OnBeat)
        {
            if (doingAnimation == false)
            {
                doingAnimation = true;
                StartCoroutine(characterAnimate(0, (float)(bpmConvert(bpm)))); 
            }
        }
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
            //characterAnimate(false);
        }
    }
}
