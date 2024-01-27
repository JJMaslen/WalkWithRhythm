using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class playerMovement : MonoBehaviour
{

    [SerializeField] GameObject character = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            character.transform.position += new Vector3(-2, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            character.transform.position += new Vector3(0, 0, -2);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            character.transform.position += new Vector3(2, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            character.transform.position += new Vector3(0, 0, 2);
        }


        if (Input.anyKeyDown)
        {
            if (metronomeScript.OnBeat)
            {
                Debug.Log("hit!");
            }
            else
            {
                Debug.Log("Miss!");
            }
        }
    }
}
