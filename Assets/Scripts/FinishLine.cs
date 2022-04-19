using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    //Creates a Variable to change how long of a delay before resetting
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;

    //When Player touches the Finshline, Reset the Level
    void OnTriggerEnter2D(Collider2D other)
    {
        //Resets the Level
        if(other.tag == "Player")
        {
            // Activates Particle Effect whens player hits the finish line
            finishEffect.Play();

            // Adds a delay before resetting the level
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", loadDelay);
            
        }
    }

    //Creates a Variable to reset the level
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}
