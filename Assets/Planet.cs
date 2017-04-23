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

[Serializable]
public class Planets
{
    [SerializeField]
    private Planet[] planets;
    public Planet this[int index]
    {
        get { return planets[index]; }
        set { planets[index] = value; }
    }

    public int Count { get { return planets.Length; } }
}

[Serializable]
public class Planet {
    private static readonly double earthMass = 5.97237 * Math.Pow(10, 24);
    private static readonly float kmEarthRadii = 6371.0f;

    [SerializeField]
    private string pl_name;
    public string Name { get { return pl_name; } }

    [SerializeField]
    private string pl_masse;
    public double Mass { get { return String.IsNullOrEmpty(pl_masse) ? 0 : earthMass * double.Parse(pl_masse); } }

    [SerializeField]
    private string pl_rade;
    public float Radius { get { return String.IsNullOrEmpty(pl_rade) ? 0 : kmEarthRadii * float.Parse(pl_rade); } } 

    [SerializeField]
    private string ra;
    public float RightAscension { get { return String.IsNullOrEmpty(ra) ? 0 : float.Parse(ra) - 180; } }

    [SerializeField]
    private string dec;
    public float Declination { get { return String.IsNullOrEmpty(dec) ? 0 : float.Parse(dec); } }

    [SerializeField]
    private string st_dist;
    public float PcDistance { get { return String.IsNullOrEmpty(st_dist) ? 0 : float.Parse(st_dist); } }

    [SerializeField]
    private string pl_disc;
    public int DiscoveryYear { get { return String.IsNullOrEmpty(pl_disc) ? 0 : int.Parse(pl_disc); } }

    [SerializeField]
    private string pl_mnum;
    public int Moons { get { return String.IsNullOrEmpty(pl_mnum) ? 0 : int.Parse(pl_mnum); } }

    [SerializeField]
    private string pl_status;
    public Status Status { get { return String.IsNullOrEmpty(pl_status) ? Status.Retracted : (Status)(int.Parse(pl_status)); } }
}
