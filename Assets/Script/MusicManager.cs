using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] public AudioClip Scene1Music; //intro 
    [SerializeField] public AudioClip Scene2Music; //Paul scene (maybe leave that empty)
    [SerializeField] public AudioClip Scene3Music; //game scene (ocean ambiance)
    [SerializeField] public AudioClip Scene4Music; //fail scene
    [SerializeField] public AudioClip Scene5Music; //Aquarium Scene

    List<AudioClip> myMusic = new List<AudioClip>();

    [SerializeField] public AudioSource MusicSource;
    [SerializeField] public AudioSource SFXSource;


    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        int currIndex = SceneManager.GetActiveScene().buildIndex;
        if (myMusic[currIndex] == null)
        {
            MusicSource.Stop();
        }
        else
        {
            MusicSource.clip = myMusic[currIndex];
            MusicSource.Play();
        }
    }
}
