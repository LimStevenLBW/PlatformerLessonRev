using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public AudioClip collectClip;
    public AudioSource audioSource;
    public Score score;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            audioSource.PlayOneShot(collectClip);
            score.Increment();
            Destroy(gameObject);
        }


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
