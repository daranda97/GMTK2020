using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRicochetSound : MonoBehaviour
{

    public List<AudioClip> clips;
    private AudioSource aSource;
    public float pitchoffset;

    // Start is called before the first frame update
    void Start() {
        aSource = GetComponent<AudioSource>();
    }

    // If the bullet comes into contact with a wall play a random sound clip.
    private void OnCollisionEnter(Collision collision)
    {
        aSource.clip = clips[Random.Range(0, clips.Count)];
        aSource.Play();
        aSource.pitch = Random.Range(1 - pitchoffset, 1 + pitchoffset);
    }
}
