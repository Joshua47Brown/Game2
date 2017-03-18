using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float shakeTimer = 1;
    public float shakeAmount;

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public float cameraSpeed;
    public Vector3 offset;
    Vector3 targetPos;
    bool running;

    public Coroutine myco;


    void Start()
    {
        StartCoroutine(ShakeCamera(0.025f,0.5f));
        targetPos = transform.position;
    }


    void FixedUpdate()
    {
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * cameraSpeed;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
        }
    }

    void Update()
    {
        if (shakeTimer >= 0)
        {
            Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;
            transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);
            shakeTimer -= Time.deltaTime;
        }
    }

    public IEnumerator ShakeCamera(float shakePower, float ShakeDur)    // Call this anywhere to shake the camera.
    {
        shakeAmount = shakePower;
        shakeTimer = ShakeDur;
        yield return running = false;
    }
}
