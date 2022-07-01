using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBreath : MonoBehaviour
{
    [Header("Dependencies")]
    public WindZone wind;
    public PechoOK2 shader;

    [Header("Debug")]
    public float lastBreathValue;
    public float weakWindThreshold = 1.5f;
    public bool exitOnFinish;

    [Header("Config")]
    public float weakWindValue = .1f;
    public float strongWindValue = .5f;
    [Range(0, 5)] public float lerpSpeed = 1;

    [Header("State")]
    public int steps;

    private void OnEnable()
    {
        //FindObjectOfType<SensorManager>().OnChestValueReceived += UpdateValue;
    }

    private void OnDisable()
    {
        //FindObjectOfType<SensorManager>().OnChestValueReceived -= UpdateValue;
    }

 
    private void UpdateValue(float newValue)
    {
        if (Mathf.Approximately(newValue, lastBreathValue)) return;

        lastBreathValue = newValue;

    }
}
