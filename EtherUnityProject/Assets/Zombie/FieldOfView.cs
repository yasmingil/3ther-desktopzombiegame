using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{


    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LayerMask layerMask2;
    private Mesh mesh;
    public static float fov;
    public static float viewDistance;
    private Vector3 origin;
    private float startingAngle;
    public bool detectPlayer;

    // Start is called before the first frame update
    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 180f;
        viewDistance = 20f;
        origin = Vector3.zero;
        detectPlayer = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        int rayCount = 100;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;


        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        detectPlayer = false;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex = origin + getVectorFromAngle(angle) * viewDistance;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, getVectorFromAngle(angle), viewDistance, layerMask); // anything but the player
            RaycastHit2D raycastHitPlayer2D = Physics2D.Raycast(origin, getVectorFromAngle(angle), viewDistance, layerMask2); // the player
            if (raycastHit2D.collider == null)
            {
                // no hit
                vertex = origin + getVectorFromAngle(angle) * viewDistance;
            } else
            {
                // hit obj
                vertex = raycastHit2D.point;
            }
            if (raycastHitPlayer2D.collider != null && raycastHit2D.collider == null) {
                detectPlayer = true;
            }
                vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    public static Vector3 getVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
    public static float getAngleFromVector(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        
        return n;
    }
    public void setOrigin(Vector3 origin)
    {
        this.origin = origin;
    }
    public void setDirection(Vector3 aimDirection)
    {
        startingAngle = getAngleFromVector(aimDirection) - fov/2f + 180;
    }
}
