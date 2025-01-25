using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{
    [SerializeField] ParticleSystem system;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paul")){
            system.gameObject.SetActive(true);
            system.Play();
            system.transform.position = new Vector3(collision.transform.position.x, transform.position.y, collision.transform.position.z);
        }
    }
}
