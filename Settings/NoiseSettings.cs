using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class NoiseSettings : ScriptableObject
{
    [SerializeField]
    [Range(0f, 5f)]
    private float noiseSeed = 0f;

    [SerializeField]
    [Range(0.2f, 2f)]
    private float noiseAmplitude = 0f;

    [SerializeField]
    [Range(0.01f, 1f)]
    private float noiseRoughness = 0f;

    public float NoiseSeed { get => noiseSeed; set => noiseSeed = value; }
    public float NoiseAmplitude { get => noiseAmplitude; set => noiseAmplitude = value; }
    public float NoiseRoughness { get => noiseRoughness; set => noiseRoughness = value; }
}
