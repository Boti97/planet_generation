using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ColorSettings : ScriptableObject
{
    [SerializeField]
    private Gradient gradient;

    [SerializeField]
    private Material material;

    public Material PlanetMaterial { get => material; set => material = value; }
    public Gradient Gradient { get => gradient; set => gradient = value; }
}