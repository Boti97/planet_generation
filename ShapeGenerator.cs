using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator
{
    readonly ShapeSettings shape;
    readonly NoiseSettings noise;

    public ShapeGenerator(ShapeSettings shape, NoiseSettings noise)
    {
        this.shape = shape;
        this.noise = noise;
    }

    public Vector3 GenerateShape(Vector3 pointOnPlanet)
    {
        return pointOnPlanet * shape.Radius;
    }

    public float GenerateSecondLayerNoise(float yPos, float xPos, NoiseSettings noise)
    {
        return noise.NoiseAmplitude * Mathf.PerlinNoise(noise.NoiseSeed + xPos, yPos * noise.NoiseRoughness);
    }
}
