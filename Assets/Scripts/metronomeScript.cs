using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class metronomeScript : MonoBehaviour
{

    public int bpm = 120;
    [SerializeField] int timer = 0;
    [SerializeField] int difficulty = 0;

    [SerializeField] double tbb;
    
    [SerializeField] GameObject character = null;
    [SerializeField] TextMeshProUGUI scoreText = null;

    public int score = 0;

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
        if (Input.anyKeyDown)
        {
            if (OnBeat)
            {
                Debug.Log("hit!");
                score = score + 1 + character.GetComponent<playerMovement>().collectedNPCList.Count;
                scoreText.text = "Score: " + score;
            }
            else
            {
                Debug.Log("Miss!");
            }
        }

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
