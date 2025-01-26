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

    private void Start()
    {
        myMusic.Add(Scene1Music);
        myMusic.Add(Scene2Music);
        myMusic.Add(Scene3Music);
        myMusic.Add(Scene4Music);
        myMusic.Add(Scene5Music);
    }

    // Update is called once per frame
    void Update()
    {
        int currIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currIndex);
        Debug.Log(myMusic.Count);
        if (myMusic[currIndex] == null)
        {
            MusicSource.Stop();
        }
        else if(MusicSource.clip == null || MusicSource.clip != myMusic[currIndex] )
        {
            MusicSource.clip = myMusic[currIndex];
            MusicSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
