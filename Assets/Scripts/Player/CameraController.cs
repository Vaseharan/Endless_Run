using UnityEngine;
using System.Collections;
using Unity.Cinemachine;


public class CameraController : MonoBehaviour
{
    [SerializeField] ParticleSystem effect;
    [SerializeField] float minFoV = 20f;
    [SerializeField] float maxFoV = 120f;
    [SerializeField] float zoomDuration = 1f;
    [SerializeField] float zoomSpeedModifier = 5f;

    CinemachineCamera cinemachineCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        cinemachineCamera = GetComponent<CinemachineCamera>();
    }
    public void ChangeCameraFOV(float speedAmount)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFOVRoutine(speedAmount));
        if (speedAmount > 0)
        {
            effect.Play();
        }
        else
        {
            effect.Stop();
        }
    }
    IEnumerator ChangeFOVRoutine(float speedAmount)
    {
        float startFOV = cinemachineCamera.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + speedAmount * zoomSpeedModifier, minFoV, maxFoV);
        float elapsedTime = 0f;
        while (elapsedTime < zoomDuration)
        {
            float t = elapsedTime / zoomDuration;
            elapsedTime += Time.deltaTime;

            cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, t);
            yield return null;
        }
        cinemachineCamera.Lens.FieldOfView = targetFOV;
    }
    
}
