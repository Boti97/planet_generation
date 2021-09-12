using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ShapeSettings : ScriptableObject
{
    [Range(5, 10)]
    [SerializeField]
    private float radius;

    public float Radius { get => radius; set => radius = value; }
}
