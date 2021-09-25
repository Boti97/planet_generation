using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseSettings
{
    [SerializeField]
    [Range(0f, 2f)]
    private float noiseAmplitude = 0f;

    [SerializeField]
    [Range(0.02f, 5f)]
    private float noiseRoughness = 0f;

    [SerializeField]
    private Vector3 noiseCenter;

    [SerializeField]
    [Range(1, 8)]
    private int numberOfLayers = 1;

    [SerializeField]
    private float baseRoughness = 1;

    [SerializeField]
    private float persistance;

    [SerializeField]
    private float minimumValue = 1;

    public float NoiseAmplitude { get => noiseAmplitude; set => noiseAmplitude = value; }
    public float NoiseRoughness { get => noiseRoughness; set => noiseRoughness = value; }
    public Vector3 Centre { get => noiseCenter; set => noiseCenter = value; }
    public int NumberOfLayers { get => numberOfLayers; set => numberOfLayers = value; }
    public float BaseRoughness { get => baseRoughness; set => baseRoughness = value; }
    public float Persistance { get => persistance; set => persistance = value; }
    public float MinimumValue { get => minimumValue; set => minimumValue = value; }
}
