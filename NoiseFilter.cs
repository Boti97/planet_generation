using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFilter
{
    private NoiseSettings noiseSettings;
    private readonly SimplexNoise simplexNoise = new SimplexNoise();

    public NoiseFilter(NoiseSettings noiseSettings)
    {
        this.noiseSettings = noiseSettings;
    }

    public float GenerateNoise(Vector3 pointOnPlanet)
    {
        float noiseValue = 0;
        float frequency = noiseSettings.BaseRoughness;
        float amplitude = 1;

        for (int i = 0; i < noiseSettings.NumberOfLayers; i++)
        {
            float v = simplexNoise.Evaluate(pointOnPlanet * frequency + noiseSettings.Centre);
            noiseValue += (v + 1) * 0.5f * amplitude;
            frequency *= noiseSettings.NoiseRoughness;
            amplitude *= noiseSettings.Persistance;
        }
        noiseValue = Mathf.Max(0, noiseValue - noiseSettings.MinimumValue);
        return noiseValue * noiseSettings.NoiseAmplitude;
    }
}
