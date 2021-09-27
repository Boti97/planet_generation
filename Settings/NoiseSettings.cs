using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseSettings
{
    [Range(0f, 2f)]
    public float noiseAmplitude = 0f;
    [Range(0.02f, 5f)]
    public float noiseRoughness = 0f;
    public Vector3 noiseCenter;
    [Range(1, 8)]
    public int numberOfLayers = 1;
    public float baseRoughness = 1;
    public float persistance;
    public float minimumValue = 1;
}
