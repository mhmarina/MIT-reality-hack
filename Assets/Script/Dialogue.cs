using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
    [SerializeField] TextMeshProUGUI captionText;
    [SerializeField] AudioSource audioSource;
    private int index = 0;

    void Start()
    {
        if (dialogueItems.Count > 0)
        {
            StartCoroutine(PlayDialogue());
        }
    }

    IEnumerator PlayDialogue()
    {
        while (index < dialogueItems.Count)
        {
            DialogueItem currentItem = dialogueItems[index];
            captionText.text = currentItem.dialogueLine;

            if (currentItem.voiceLine != null)
            {
                audioSource.clip = currentItem.voiceLine;
                audioSource.Play();
                // wait for the length of the voice clip before incrementing index
                yield return new WaitForSeconds(audioSource.clip.length);
            }
            else
            {
                yield return new WaitForSeconds(3f); // wait arbitrary num of secs if not voice line
            }

            currentItem.action?.Invoke();

            // increment index
            index++;
        }
        captionText.text = ""; // Clear the caption when dialogue is finished
    }

    public void PlayNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
