using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandIconMovement : MonoBehaviour
{ 
    public float rotationSpeed = 1f;
    public float rotationRange = 60f;

    private Quaternion startRot;
    private Quaternion aimRot;

    void Start()
    {
        startRot = transform.localRotation;
        aimRot = Quaternion.Euler(Vector3.forward * rotationRange);
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * rotationSpeed, 1f);

        transform.localRotation = Quaternion.Lerp(startRot, aimRot, t);
    }
}
