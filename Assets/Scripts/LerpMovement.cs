using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMovement : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.0f;

    private float journeyLength;
    private float startTime;

    private void Start()
    {
        journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
        startTime = Time.time;
    }

    private void Update()
    {
        float distanceCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distanceCovered / journeyLength;
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, fractionOfJourney);

        if (fractionOfJourney >= 1.0f)
        {
            // Yönü tersine çevir
            Vector3 temp = startPoint.position;
            startPoint.position = endPoint.position;
            endPoint.position = temp;
            startTime = Time.time;
        }
    }
}
