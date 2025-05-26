using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingCube : MonoBehaviour
{
    public static MovingCube CurrentCube {  get; private set; }
    public static MovingCube LastCube { get; private set; }

    [SerializeField]
    private float moveSpeed = 1f;

    private void OnEnable()
    {
        if (CurrentCube == null)
            LastCube = GameObject.Find("Start").GetComponent<MovingCube>() ;

        CurrentCube = this;
    }

    internal void Stop()
    {
        moveSpeed = 0;
        float hangover = transform.position.z - LastCube.transform.position.z;

        SplitCubeOnZ(hangover);
        Debug.Log(hangover);
    }

    private void SplitCubeOnZ(float hangover)
    {
        float newZSize = LastCube.transform.localScale.z - Mathf.Abs(hangover);
        float fallingBlockSize = transform.localScale.z * newZSize;

        float newZPosition = LastCube.transform.position.z + (hangover / 2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newZSize);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);

        float cubeEdge = transform.position.z + (newZSize / 2f);
        float fallingBlockZPosition = cubeEdge + fallingBlockSize / 2f;

        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(transform.position.x, transform.position.y, cubeEdge);
        sphere.transform.localScale = Vector3.one * 0.1f;

        SpawnDropCube(fallingBlockZPosition, fallingBlockZPosition);
    }

    private void SpawnDropCube(float fallingBlockZPosition, float fallingBlockSize)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, fallingBlockSize);
        cube.transform.position = new Vector3(transform.position.x, transform.position.y, fallingBlockZPosition);

    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;

    }

}
