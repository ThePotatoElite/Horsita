using UnityEngine;

public class TerrainController : MonoBehaviour
{
    [SerializeField] SussitaManager sussitaManager;
    [SerializeField] MeshFilter Terrain;
    [SerializeField] MeshCollider TerrainCollider;
    [SerializeField] float amplitude = 1;
    [SerializeField] float frequency = 1;

    Vector3[] Vertexes;
    Vector3[] StartingPosition;

    float distance;

    void Start()
    {
        Vertexes = Terrain.mesh.vertices;
        StartingPosition = Terrain.mesh.vertices;
        distance = 0;

        if (sussitaManager == null)
            sussitaManager = SussitaManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime * sussitaManager.GetCurrentSpeed();

        for (int i = 0; i < Vertexes.Length; i++)
        {
            Vertexes[i] = new Vector3(Vertexes[i].x, StartingPosition[i].y + amplitude*Mathf.Sin(frequency*distance+ Vertexes[i].x), Vertexes[i].z);
        }
        Terrain.mesh.vertices = Vertexes;
        TerrainCollider.sharedMesh = Terrain.mesh;
    }
}
