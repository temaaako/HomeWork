using UnityEngine;

[RequireComponent(typeof(Terrain))]
public class MapGenerator : MonoBehaviour
{
    [Header("GenerateSettings")]
    [SerializeField] private float _noiseScale;
    [SerializeField] private float _amplitude;
    [SerializeField] private float _amplitudeScale;
    [SerializeField] private float _frequency;
    [SerializeField] private float _lacunarity;
    [SerializeField] private int _octaves;

    [Header("Seed")]
    [SerializeField] private float _xOffset;
    [SerializeField] private float _zOffset;
    [SerializeField] private bool _random;

    private Terrain _terrain;

    private void Awake()
    {
        _terrain = GetComponent<Terrain>();
        GenerateMap();
    }

    private void GenerateMap()
    {
        TerrainData terrainData = _terrain.terrainData;

        int width = terrainData.heightmapResolution;
        int lenght = terrainData.heightmapResolution;

        float[,] heights = new float[width, lenght];

        _xOffset = _random ? Random.Range(0, 1000) : _xOffset;
        _zOffset = _random ? Random.Range(0, 1000) : _zOffset;

        for (int x = 0; x < lenght; x++)
        {
            for (int z = 0; z < width; z++)
            {
                float xCoord = (float)x / width * _noiseScale + _xOffset;
                float zCoord = (float)z / lenght * _noiseScale + _zOffset;

                float sample = CalculateHeight(xCoord, zCoord, _octaves, _lacunarity);

                float y = transform.position.y + (sample * terrainData.heightmapResolution);

                heights[x, z] = sample;
            }
        }

        terrainData.SetHeights(0, 0, heights);
    }

    private float CalculateHeight(float x, float y, int octaves, float lacunarity)
    {
        float sum = 0f;
        float amplitude = _amplitude;
        float frequency = _frequency;

        for (int i = 0; i < octaves; i++)
        {
            sum += Mathf.PerlinNoise(x * frequency, y * frequency) * amplitude;
            frequency *= lacunarity;
            amplitude *= _amplitudeScale;
        }

        return sum;
    }
}
