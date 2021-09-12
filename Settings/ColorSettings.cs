using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ColorSettings : ScriptableObject
{
    [SerializeField]
    private Color planetColor;

    public Color PlanetColor { get => planetColor; set => planetColor = value; }
}