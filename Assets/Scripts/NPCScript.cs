using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class NPCScript : MonoBehaviour
{

    public GameObject player = null;
    public GameObject npc = null;
    public GameObject startCube = null;

    public bool collected = false;
    public int positionInList = 99;

    bool doingAnimation = false;

    IEnumerator characterAnimate(float time, float duration)
    {
        float lerp;
        while (time < duration)
        {
            lerp = Mathf.Lerp(0.6f, 1, time / duration);
            npc.transform.localScale = new Vector3(npc.transform.localScale.x, lerp, npc.transform.localScale.z);
            time += Time.deltaTime;
            yield return null;
        }
        doingAnimation = false;
    }

    IEnumerator characterMove(float time, float duration)
    {
        float lerp;
        while (time < duration)
        {

            yield return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startCube.GetComponent<metronomeScript>().OnBeat)
        {
            if (doingAnimation == false)
            {
                doingAnimation = true;
                StartCoroutine(characterAnimate(0, (float)startCube.GetComponent<metronomeScript>().bpmConvert(startCube.GetComponent<metronomeScript>().bpm)));
            }
        }
    }

    public void moveNPC()
    {
        if (collected)
        {
            npc.transform.position = player.GetComponent<playerMovement>().previousPositons[positionInList];
        }
    }
}
