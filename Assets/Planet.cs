using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status
{
    Retracted,
    Announced,
    Submitted,
    Accepted
}

public class Planet : ScriptableObject {
    private static readonly double earthMass = 5.97237 * Math.Pow(10, 24);
    private static readonly float kmEarthRadii = 6371.0f;

    public string Name;
    private double mass;
    public double Mass
    {
        get
        {
            return earthMass * mass;
        }
    }

    private float radius;
    public float Radius
    {
        get
        {
            return Radius * kmEarthRadii;
        }
    }

    public float RightAscension;
    public float Declination;
    public float PcDistance;
    public int DiscoveryYear;
    public int Moons;
    public Status Status;
}
