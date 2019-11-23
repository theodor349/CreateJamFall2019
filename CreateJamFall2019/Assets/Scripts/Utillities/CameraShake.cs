using UnityEngine;
using System.Collections;
public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 1.5f;
    [SerializeField] private float shakeMagnitude = 0.5f;
    [SerializeField] private float dampingSpeed = 10.0f;

    private float shakeTime;
    Vector3 initialPosition;

    void Update() {
        if (shakeTime > 0) {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeTime -= Time.deltaTime * dampingSpeed;
        } else {
            shakeTime = 0f;
        }
    }

    public void Shake() {
        initialPosition = transform.localPosition;
        shakeTime = shakeDuration;
    }
}