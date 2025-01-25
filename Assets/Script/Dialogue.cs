using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{
    // Start is called before the first frame update

    [System.Serializable]
    public class DialogueItem
    {
        public string dialogueLine;
        public AudioClip voiceLine;     
        public UnityEvent action; // whatever action should be called after this voiceline plays.
    }

    [SerializeField] public List<DialogueItem> dialogueItems = new List<DialogueItem>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
