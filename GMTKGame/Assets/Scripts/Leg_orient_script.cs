using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg_orient_script : MonoBehaviour
{

    public List<GameObject> walking_axes;
    public GameObject marionet;

    // Start is called before the first frame update
    void Start()
    {
        marionet.transform.LookAt(walking_axes[0].transform.position);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A))
        {

            marionet.transform.LookAt(walking_axes[1].transform.position);

        }
        if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.D))
        {

            marionet.transform.LookAt(walking_axes[3].transform.position);

        }

        if (Input.GetKeyDown(KeyCode.W))
        {

            marionet.transform.LookAt(walking_axes[2].transform.position);

        }

        if (Input.GetKeyDown(KeyCode.A))
        {

            marionet.transform.LookAt(walking_axes[0].transform.position);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {

            marionet.transform.LookAt(walking_axes[4].transform.position);

        }
        

    }


}
