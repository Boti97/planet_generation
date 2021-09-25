using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    private ShapeSettings shapeSettings;
    private NoiseFilter[] noiseFilters;
    private MinMax elevationMinMax;

    public MinMax ElevationMinMax { get => elevationMinMax; set => elevationMinMax = value; }

    public void UpdateSettings(ShapeSettings shapeSettings)
    {
        this.shapeSettings = shapeSettings;
        noiseFilters = new NoiseFilter[shapeSettings.NoiseLayers.Length];
        for (int i = 0; i < noiseFilters.Length; i++)
        {
            noiseFilters[i] = new NoiseFilter(shapeSettings.NoiseLayers[i].noiseSettings);
        }
        ElevationMinMax = new MinMax();
    }

    public Vector3 GenerateShape(Vector3 pointOnPlanet)
    {
        float elevation = 0;
        float firstLayerValue = 0;

        if (noiseFilters.Length > 0)
        {
            firstLayerValue = noiseFilters[0].GenerateNoise(pointOnPlanet);
            if (shapeSettings.NoiseLayers[0].enabled)
            {
                elevation = firstLayerValue;
            }
        }

        for (int i = 1; i < noiseFilters.Length; i++)
        {
            if (shapeSettings.NoiseLayers[i].enabled)
            {
                float mask = (shapeSettings.NoiseLayers[i].useFirstLayerAsMask) ? firstLayerValue : 1;
                elevation += noiseFilters[i].GenerateNoise(pointOnPlanet) * mask;
            }
        }
        elevation = shapeSettings.Radius * (1 + elevation);
        ElevationMinMax.AddValue(elevation);
        return pointOnPlanet * elevation;
    }
}
