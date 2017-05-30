﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMeshGenerator : MonoBehaviour {

    public Material[] Materials;

    private float _cubeWidth;
    private float _cubeHeight;
    private float _cubeLenght;

    private void Start()
    {
        _cubeHeight = 2;
        _cubeWidth = 2;
        _cubeLenght = 2;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            CreateCube();
        }
    }

    private Vector3[] GetVertices()
	{
		Vector3 vertice_0 = new Vector3(-_cubeLenght * .5f, -_cubeWidth * .5f, _cubeHeight * .5f);
		Vector3 vertice_1 = new Vector3(_cubeLenght * .5f, -_cubeWidth * .5f, _cubeHeight * .5f);
		Vector3 vertice_2 = new Vector3(_cubeLenght * .5f, -_cubeWidth * .5f, -_cubeHeight * .5f);
		Vector3 vertice_3 = new Vector3(-_cubeLenght * .5f, -_cubeWidth * .5f, -_cubeHeight * .5f);
		Vector3 vertice_4 = new Vector3(-_cubeLenght * .5f, _cubeWidth * .5f, _cubeHeight * .5f);
		Vector3 vertice_5 = new Vector3(_cubeLenght * .5f, _cubeWidth * .5f, _cubeHeight * .5f);
		Vector3 vertice_6 = new Vector3(_cubeLenght * .5f, _cubeWidth * .5f, -_cubeHeight * .5f);
		Vector3 vertice_7 = new Vector3(-_cubeLenght * .5f, _cubeWidth * .5f, -_cubeHeight * .5f);
		
        Vector3[] vertices = new Vector3[]
        {   
			// Bottom Polygon
			vertice_0, vertice_1, vertice_2, vertice_0,
            // Left Polygon
            vertice_7, vertice_4, vertice_0, vertice_3,
            // Front Polygon
            vertice_4, vertice_5, vertice_1, vertice_0,
            // Back Polygon
            vertice_6, vertice_7, vertice_3, vertice_2,
            // Right Polygon
            vertice_5, vertice_6, vertice_2, vertice_1,
            // Top Polygon
            vertice_7, vertice_6, vertice_5, vertice_4
        };

	    return vertices;
	}

	private Vector3[] GetNormals()
	{
		Vector3 up = Vector3.up;
		Vector3 down = Vector3.down;
		Vector3 front = Vector3.forward;
		Vector3 back = Vector3.back;
		Vector3 left = Vector3.left;
		Vector3 right = Vector3.right;

		Vector3[] normals = new Vector3[]
        {
			// Bottom Side Render
			down, down, down, down,
			// LEFT Side Render
			left, left, left, left,
			// FRONT Side Render
			front, front, front, front,
			// BACK Side Render
			back, back, back, back,
			// RIGTH Side Render
			right, right, right, right,
			// UP Side Render
			up, up, up, up
		};

		return normals;
	}

	private Vector2[] GetUVsMap()
	{
		Vector2 _00_CORDINATES = new Vector2(0f, 0f);
		Vector2 _10_CORDINATES = new Vector2(1f, 0f);
		Vector2 _01_CORDINATES = new Vector2(0f, 1f);
		Vector2 _11_CORDINATES = new Vector2(1f, 1f);

		Vector2[] uvs = new Vector2[]
        {
			// Bottom
			_11_CORDINATES, _01_CORDINATES, _00_CORDINATES, _10_CORDINATES,
			// Left
			_11_CORDINATES, _01_CORDINATES, _00_CORDINATES, _10_CORDINATES,
			// Front
			_11_CORDINATES, _01_CORDINATES, _00_CORDINATES, _10_CORDINATES,
			// Back
			_11_CORDINATES, _01_CORDINATES, _00_CORDINATES, _10_CORDINATES,
			// Right
			_11_CORDINATES, _01_CORDINATES, _00_CORDINATES, _10_CORDINATES,
			// Top
			_11_CORDINATES, _01_CORDINATES, _00_CORDINATES, _10_CORDINATES,
        };

		return uvs;
	}

	private int[] GetTriangles()
	{
		int[] triangles = new int[]
        {
			// Cube Bottom Side Triangles
			3, 1, 0,
			3, 2, 1,    
			// Cube Left Side Triangles
			3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
			3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,
			// Cube Front Side Triangles
			3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
			3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,
			// Cube Back Side Triangles
			3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
			3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,
			// Cube Rigth Side Triangles
			3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
			3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,
			// Cube Top Side Triangles
			3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
			3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,
        };

		return triangles;
	}


	private Mesh GetCubeMesh()
	{
        if (GetComponent<Mesh>() == null)
		{
            MeshFilter filter = gameObject.AddComponent<MeshFilter>();
            Mesh mesh = new Mesh();
            filter.mesh = mesh;
			mesh.Clear();
			return mesh;
		}
		else
		{
            return gameObject.AddComponent<MeshFilter>().mesh;
		}
	}

    private void CreateCube()
    {
        var cube = GenerateCube();
        var cubeMesh = cube.GetComponent<MeshFilter>().mesh;
        cubeMesh.vertices = GetVertices();
        cubeMesh.normals = GetNormals();
        cubeMesh.uv = GetUVsMap();
        cubeMesh.triangles = GetTriangles();
        cubeMesh.RecalculateBounds();
        cubeMesh.RecalculateNormals();
        cubeMesh.name = "CubeMesh";
    }

    private GameObject GenerateCube()
    {
        var cube = new GameObject("Cube");
        cube.AddComponent<MeshRenderer>();
        cube.AddComponent<MeshFilter>();
        cube.GetComponent<MeshFilter>().mesh = new Mesh();

        cube.GetComponent<MeshRenderer>().material = Materials[UnityEngine.Random.Range(0, Materials.Length)];

        return cube;
    }

}
