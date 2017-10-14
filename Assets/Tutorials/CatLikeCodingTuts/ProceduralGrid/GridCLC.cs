using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//http://catlikecoding.com/unity/tutorials/procedural-grid/

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GridCLC : MonoBehaviour {

    public int XSize;
    public int YSize;

    private Vector3[] _vertices;

    private Mesh _mesh;

    private void Awake()
    {
        //StartCoroutine("GenerateSlowly");
        Generate();
    }

    private void Generate()
    {
		GetComponent<MeshFilter>().mesh = _mesh = new Mesh();
		_mesh.name = "Procedural Grid";

        _vertices = new Vector3[(XSize + 1) * (YSize + 1)];
        Vector2[] uv = new Vector2[_vertices.Length];
        Vector4[] tangents = new Vector4[_vertices.Length];
		Vector4 tangent = new Vector4(1f, 0f, 0f, -1f);

        for (int i = 0, y = 0; y <= YSize; y++)
		{
            for (int x = 0; x <= XSize; x++, i++)
			{
                _vertices[i] = new Vector3(x, y);
                uv[i] = new Vector2((float)x / XSize, (float)y / YSize);
                tangents[i] = tangent;
			}
		}
        _mesh.vertices = _vertices;
        _mesh.uv = uv;

        int[] triangles = new int[XSize * YSize * 6];
        for (int ti = 0, vi = 0, y = 0; y < YSize; y++, vi++)
		{
            for (int x = 0; x < XSize; x++, ti += 6, vi++)
			{
				triangles[ti] = vi;
				triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + XSize + 1;
                triangles[ti + 5] = vi + XSize + 2;
			}
		}
        _mesh.triangles = triangles;

        _mesh.RecalculateNormals();

        _mesh.tangents = tangents;
    }

    private IEnumerator GenerateSlowly()
    {
        var wait = new WaitForSeconds(.05f);

        _mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _mesh;
        _mesh.name = "Procedural Grid";

		_vertices = new Vector3[(XSize + 1) * (YSize + 1)];

		for (int i = 0, y = 0; y <= YSize; y++)
		{
			for (int x = 0; x <= XSize; x++, i++)
			{
				_vertices[i] = new Vector3(x, y);
			}
		}

        _mesh.vertices = _vertices;

        int[] triangles = new int[XSize * 6 * YSize];
        for (int ti = 0, vi = 0, y = 0; y < YSize; y++, vi++)
        {
            for (int x = 0; x < XSize; x++, ti += 6, vi++)
            {
				triangles[ti] = vi;
				triangles[ti + 3] = triangles[ti + 2] = vi + 1;
				triangles[ti + 4] = triangles[ti + 1] = vi + XSize + 1;
				triangles[ti + 5] = vi + XSize + 2;

				_mesh.triangles = triangles;
				yield return wait;
            }
        }


    }

    private void OnDrawGizmos()
    {

        if (_vertices == null)
        {
            return;
        }

        Gizmos.color = Color.green;
        for (int i = 0; i < _vertices.Length; i++)
        {
            Gizmos.DrawSphere(_vertices[i], .1f);
        }
    }
}
