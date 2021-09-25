using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ShapeSettings : ScriptableObject
{
    [Range(5, 10)]
    [SerializeField]
    private float radius;

    [SerializeField]
    private NoiseLayer[] noiseLayers;

    public float Radius { get => radius; set => radius = value; }
    public NoiseLayer[] NoiseLayers { get => noiseLayers; set => noiseLayers = value; }

    [System.Serializable]
    public class NoiseLayer
    {
        public bool enabled = true;
        public bool useFirstLayerAsMask;
        public NoiseSettings noiseSettings;
    }
}
