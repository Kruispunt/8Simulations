using UnityEngine;

public class Directies
{
    public Vector3 North = Vector3.back;

    public Vector3 South = Vector3.forward;

    public Vector3 East = Vector3.left;

    public Vector3 West = Vector3.right;
}


public enum Turn
{
    right,
    left,
    forward
}