using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class playerMovement : MonoBehaviour
{

    [SerializeField] GameObject character = null;
    [SerializeField] GameObject npcs = null;

    List<GameObject> npcsList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < npcs.transform.childCount; i++)
        {
            npcsList.Add(npcs.transform.GetChild(i).gameObject);

        }
    }

    void checkNPC()
    {
        for (int i = 0; i < npcsList.Count; i++)
        {
            if (character.transform.position.x == npcsList[i].transform.position.x)
            {
                if (character.transform.position.z == npcsList[i].transform.position.z)
                {
                    Debug.Log("Collected");
                }
                else
                {
                    Debug.Log("Not Collected");
                }
            }
            else
            {
                Debug.Log("Not collected");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            character.transform.position += new Vector3(-4, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            character.transform.position += new Vector3(0, 0, -4);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            character.transform.position += new Vector3(4, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            character.transform.position += new Vector3(0, 0, 4);
        }


        if (Input.anyKeyDown)
        {
            checkNPC();
            if (metronomeScript.OnBeat)
            {
                //Debug.Log("hit!");
            }
            else
            {
                //Debug.Log("Miss!");
            }
        }
    }
}
