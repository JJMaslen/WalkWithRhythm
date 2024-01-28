using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class playerMovement : MonoBehaviour
{

    [SerializeField] GameObject character = null;
    [SerializeField] GameObject npcs = null;

    List<GameObject> npcsList = new List<GameObject>();
    public List<GameObject> collectedNPCList = new List<GameObject>();

    public List<Vector3> previousPositons = new List<Vector3>();

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
                    if (npcsList[i].GetComponent<NPCScript>().collected == false)
                    {
                        npcsList[i].GetComponent<NPCScript>().collected = true;
                        npcsList[i].GetComponent<NPCScript>().positionInList = collectedNPCList.Count;
                        collectedNPCList.Add(npcsList[i]);
                    }
                }
            }
        }
    }

    void addToPositionsList(Vector3 currentPostiton)
    {
        previousPositons.Insert(0,currentPostiton);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            checkNPC();

            for (int i = 0; i < npcsList.Count; i++)
            {
                if (npcsList[i].GetComponent<NPCScript>().collected)
                {
                    npcsList[i].GetComponent<NPCScript>().moveNPC();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            addToPositionsList(character.transform.position);
            character.transform.position += new Vector3(-4, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            addToPositionsList(character.transform.position);
            character.transform.position += new Vector3(0, 0, -4);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            addToPositionsList(character.transform.position);
            character.transform.position += new Vector3(4, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            addToPositionsList(character.transform.position);
            character.transform.position += new Vector3(0, 0, 4);
        }
    }
}
