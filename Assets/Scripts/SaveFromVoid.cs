using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveFromVoid : MonoBehaviour
{
    Rigidbody rb;
    public float minYDepth = 50;
    public Vector3 respawnPoint = new Vector3(0, 5, 0);

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (gameObject.transform.position.y <= minYDepth)
        {
            rb.velocity = Vector3.zero;
            gameObject.transform.position = respawnPoint;
        }
    }
}
