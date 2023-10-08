using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainFace
{
    ShapeGenerator shapeGenerator;

    Mesh mesh;
    int resolution;

    Vector3 faceUp;
    Vector3 axisX;
    Vector3 axisY;

    public TerrainFace(ShapeGenerator shapeGenerator ,Mesh mesh, int resolution, Vector3 faceUp)
    {
        this.shapeGenerator = shapeGenerator;
        this.mesh = mesh;
        this.resolution = resolution;
        this.faceUp = faceUp;

        axisX = new Vector3(faceUp.y, faceUp.z, faceUp.x);
        axisY = Vector3.Cross(faceUp, axisX);

    }

    // creating mesh for object (resolution is number of vertices on one side)
    public void MeshConstruct()
    {
        Vector3[] vertices = new Vector3[resolution * resolution];

        int[] triangles = new int[(resolution - 1) * (resolution - 1) * 6];
        int triIndex = 0;


        for (int y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++)
            {

                int i = x + y * resolution;
                Vector2 percent = new Vector2(x, y) / (resolution - 1);
                Vector3 pointOnUnitCube = faceUp + (percent.x - .5f) * 2 * axisX + (percent.y - .5f) * 2 * axisY;
                Vector3 pointOnUnitSphere = pointOnUnitCube.normalized;
                vertices[i] = shapeGenerator.CalculatePointOnPlanet(pointOnUnitSphere);

                if (x != resolution - 1 && y != resolution - 1)
                {
                    triangles[triIndex] = i;
                    triangles[triIndex + 1] = i + resolution + 1;
                    triangles[triIndex + 2] = i + resolution;

                    triangles[triIndex + 3] = i;
                    triangles[triIndex + 4] = i + 1;
                    triangles[triIndex + 5] = i + resolution + 1;
                    triIndex += 6;
                }

            }
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

    }
}
