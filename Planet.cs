
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    //on UI
    [SerializeField]
    private ShapeSettings shape;

    [SerializeField]
    private NoiseSettings noise;

    [SerializeField]
    private ColorSettings color;

    [Range(2, 256)]
    [SerializeField]
    private int resolution = 10;

    [SerializeField]
    private bool autoUpdate = true;

    //other variables
    private MeshFilter[] meshFilters;
    private TerrainFace[] terrainFaces;
    private ShapeGenerator shapeGenerator;
    [HideInInspector]
    public bool shapeSettingsFoldout;
    [HideInInspector]
    public bool colorSettingsFoldout;
    [HideInInspector]
    public bool noiseSettingsFoldout;
    private Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

    public ShapeSettings Shape { get => shape; set => shape = value; }
    public NoiseSettings Noise { get => noise; set => noise = value; }
    public ColorSettings Color { get => color; set => color = value; }

    public void GeneratePlanet()
    {
        Initialize();
        GenerateMesh();
        SetColor();
    }

    public void OnColorSettingsUpdated()
    {
        if (autoUpdate)
        {
            Initialize();
            SetColor();
        }
    }

    public void OnShapeAndNoiseSettingsUpdated()
    {
        if (autoUpdate)
        {
            Initialize();
            GenerateMesh();
        }
    }

    void Initialize()
    {
        shapeGenerator = new ShapeGenerator(Shape, Noise);
        if (meshFilters == null || meshFilters.Length == 0)
        {
            meshFilters = new MeshFilter[6];
        }
        terrainFaces = new TerrainFace[6];

        for (int i = 0; i < 6; i++)
        {
            if (meshFilters[i] == null)
            {
                GameObject meshObj = new GameObject("TerrainFace");
                meshObj.transform.parent = transform;

                meshObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }

            terrainFaces[i] = new TerrainFace(meshFilters[i].sharedMesh, directions[i], resolution, shapeGenerator);
        }
    }

    void GenerateMesh()
    {
        foreach (TerrainFace face in terrainFaces)
        {
            face.ConstructMesh();
        }
    }

    void SetColor()
    {
        foreach (MeshFilter meshFilter in meshFilters)
        {
            meshFilter.GetComponent<MeshRenderer>().sharedMaterial.color = Color.PlanetColor;
        }
    }
}