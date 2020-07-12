using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            float interpolation = speed * (Vector3.Distance(player.position, new Vector3(transform.position.x, player.position.y, transform.position.z))) * Time.deltaTime;

            Vector3 position = this.transform.position;
            position.z = Mathf.Lerp(this.transform.position.z, player.position.z, interpolation);
            position.x = Mathf.Lerp(this.transform.position.x, player.position.x, interpolation);

            this.transform.position = position;
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, player.position.z), speed * Time.deltaTime);
        }
    }
}
