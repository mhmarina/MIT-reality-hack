using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_PlayerController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Transform>().localPosition += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * 5, 0, Input.GetAxis("Vertical") * Time.deltaTime * 5);
    }
}
