using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUp : MonoBehaviour
{
    [SerializeField] float maxHeight = 50f;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime;
        if(transform.position.y >= maxHeight)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
