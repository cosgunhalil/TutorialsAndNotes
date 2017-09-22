using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class RoundedCube : MonoBehaviour {

	public int XSize;
	public int YSize;
	public int ZSize;
    public int Roundness;

	private Mesh _mesh;
	private Vector3[] _vertices;
    private Vector3[] _normals;

	private void Awake()
	{
		Generate();
	}

	private void Generate()
	{
		_mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = _mesh;
		_mesh.name = "Procedural Cube";
		CreateVertices();
		CreateTriangles();

	}

	private void CreateVertices()
	{
		int cornerVertices = 8;
		int edgeVertices = (XSize + YSize + ZSize - 3) * 4;

		int faceVertices = (
			(XSize - 1) * (YSize - 1) +
			(XSize - 1) * (ZSize - 1) +
			(YSize - 1) * (ZSize - 1)) * 2;

		_vertices = new Vector3[cornerVertices + edgeVertices + faceVertices];
        _normals = new Vector3[_vertices.Length];

		int v = 0;

        for (int y = 0; y <= YSize; y++)
		{
            for (int x = 0; x <= XSize; x++)
			{
				SetVertex(v++, x, y, 0);
			}
            for (int z = 1; z <= ZSize; z++)
			{
                SetVertex(v++, XSize, y, z);
			}
            for (int x = XSize - 1; x >= 0; x--)
			{
                SetVertex(v++, x, y, ZSize);
			}
            for (int z = ZSize - 1; z > 0; z--)
			{
				SetVertex(v++, 0, y, z);
			}
		}
        for (int z = 1; z < ZSize; z++)
		{
            for (int x = 1; x < XSize; x++)
			{
                SetVertex(v++, x, YSize, z);
			}
		}
        for (int z = 1; z < ZSize; z++)
		{
            for (int x = 1; x < XSize; x++)
			{
				SetVertex(v++, x, 0, z);
			}
		}


		_mesh.vertices = _vertices;
        _mesh.normals = _normals;
	}

	private void SetVertex(int i, int x, int y, int z)
	{
        _vertices[i] = new Vector3(x, y, z);
        Vector3 inner = _vertices[i];

        if (x < Roundness)
		{
            inner.x = Roundness;
		}
        else if (x > XSize - Roundness)
		{
            inner.x = XSize - Roundness;
		}
        if (y < Roundness)
		{
            inner.y = Roundness;
		}
        else if (y > YSize - Roundness)
		{
            inner.y = YSize - Roundness;
		}

        _normals[i] = (_vertices[i] - inner).normalized;
        _vertices[i] = inner + _normals[i] * Roundness;
	}

	private void CreateTriangles()
	{
		int quads = (XSize * YSize + XSize * ZSize + YSize * ZSize) * 2;
		var triangles = new int[quads * 6];
		int ring = (XSize + ZSize) * 2;
		int t = 0;
		int v = 0;

		for (int y = 0; y < YSize; y++, v++)
		{
			for (int q = 0; q < ring - 1; q++, v++)
			{
				t = SetQuad(triangles, t, v, v + 1, v + ring, v + ring + 1);
			}

			t = SetQuad(triangles, t, v, v - ring + 1, v + ring, v + 1);
		}

		t = CreateTopFace(triangles, t, ring);
		t = CreateBottomFace(triangles, t, ring);
		_mesh.triangles = triangles;
	}

	private static int SetQuad(int[] triangles, int i, int v00, int v10, int v01, int v11)
	{
		triangles[i] = v00;
		triangles[i + 1] = triangles[i + 4] = v01;
		triangles[i + 2] = triangles[i + 3] = v10;
		triangles[i + 5] = v11;
		return i + 6;
	}

	private int CreateTopFace(int[] triangles, int t, int ring)
	{
		int v = ring * YSize;
		for (int x = 0; x < XSize - 1; x++, v++)
		{
			t = SetQuad(triangles, t, v, v + 1, v + ring - 1, v + ring);
		}
		t = SetQuad(triangles, t, v, v + 1, v + ring - 1, v + 2);

		int vMin = ring * (YSize + 1) - 1;
		int vMid = vMin + 1;
		int vMax = v + 2;

		for (int z = 1; z < ZSize - 1; z++, vMin--, vMid++, vMax++)
		{
			t = SetQuad(triangles, t, vMin, vMid, vMin - 1, vMid + XSize - 1);

			for (int x = 1; x < XSize - 1; x++, vMid++)
			{
				t = SetQuad(
					triangles, t,
					vMid, vMid + 1, vMid + XSize - 1, vMid + XSize);
			}

			t = SetQuad(triangles, t, vMid, vMax, vMid + XSize - 1, vMax + 1);
		}

		int vTop = vMin - 2;
		t = SetQuad(triangles, t, vMin, vMid, vTop + 1, vTop);
		for (int x = 1; x < XSize - 1; x++, vTop--, vMid++)
		{
			t = SetQuad(triangles, t, vMid, vMid + 1, vTop, vTop - 1);
		}
		t = SetQuad(triangles, t, vMid, vTop - 2, vTop, vTop - 1);

		return t;
	}

	private int CreateBottomFace(int[] triangles, int t, int ring)
	{
		int v = 1;
		int vMid = _vertices.Length - (XSize - 1) * (ZSize - 1);
		t = SetQuad(triangles, t, ring - 1, vMid, 0, 1);
		for (int x = 1; x < XSize - 1; x++, v++, vMid++)
		{
			t = SetQuad(triangles, t, vMid, vMid + 1, v, v + 1);
		}
		t = SetQuad(triangles, t, vMid, v + 2, v, v + 1);

		int vMin = ring - 2;
		vMid -= XSize - 2;
		int vMax = v + 2;

		for (int z = 1; z < ZSize - 1; z++, vMin--, vMid++, vMax++)
		{
			t = SetQuad(triangles, t, vMin, vMid + XSize - 1, vMin + 1, vMid);
			for (int x = 1; x < XSize - 1; x++, vMid++)
			{
				t = SetQuad(
					triangles, t,
					vMid + XSize - 1, vMid + XSize, vMid, vMid + 1);
			}
			t = SetQuad(triangles, t, vMid + XSize - 1, vMax + 1, vMid, vMax);
		}

		int vTop = vMin - 1;
		t = SetQuad(triangles, t, vTop + 1, vTop, vTop + 2, vMid);
		for (int x = 1; x < XSize - 1; x++, vTop--, vMid++)
		{
			t = SetQuad(triangles, t, vTop, vTop - 1, vMid, vMid + 1);
		}
		t = SetQuad(triangles, t, vTop, vTop - 1, vMid, vTop - 2);

		return t;
	}

	private void OnDrawGizmos()
	{
		if (_vertices == null)
		{
			return;
		}

		for (int i = 0; i < _vertices.Length; i++)
		{
			Gizmos.color = Color.black;
			Gizmos.DrawSphere(_vertices[i], 0.1f);
			Gizmos.color = Color.yellow;
			Gizmos.DrawRay(_vertices[i], _normals[i]);
		}
	}
	
}
