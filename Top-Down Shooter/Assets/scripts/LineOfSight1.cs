using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyClass;

public class LineOfSight1 : MonoBehaviour
{
    static LineOfSight1 _instance;

    public static LineOfSight1 GetLOS()
    {
        return _instance;
    }
    private void Awake()
    {
        _instance = this;
    }


    public float offset=-90f;

    Mesh mesh;
    public LayerMask obj;
    Vector3 origin;
    float startingangle;
    [HideInInspector]public float fov;
    float angle;
    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
    }
    private void LateUpdate()
    {
        fov = 90f;
      
        int raycount = 90;
        angle = startingangle;
        float anglrIncrease = fov / raycount;
        float viewdistance=50f;

        Vector3[] vertices = new Vector3[raycount+2];
        int[] triangles = new int[raycount*3];

        vertices[0] = origin;

        int triangleIndex = 0;
        int vertexIndex = 1;
        for(int i = 0; i <= raycount; i++)
        {
            Vector3 vertex;
           RaycastHit2D raycastHit2D= Physics2D.Raycast(origin, Maths.Calculate.VectorFor(angle), viewdistance,obj);
            if (raycastHit2D.collider == null)
            {
                vertex = origin + Maths.Calculate.VectorFor(angle) * viewdistance;
            }
            else
            {
                vertex = raycastHit2D.point;

               
            }


            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= anglrIncrease;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.bounds = new Bounds(Vector3.zero, Vector3.one*1000f);
    }

   
    public void SetOrigin(Vector3 originpoint) {
       origin = originpoint;
 }
    public void SetAim(Vector3 Dir)
    {
        startingangle = (Maths.Calculate.AngleFor(Dir) - fov / 2f)+offset;
    }
    public Vector3 GetPos()
    {
        return origin;
    }

   
}
