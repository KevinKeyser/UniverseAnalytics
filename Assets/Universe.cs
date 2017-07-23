using System.IO;
using UnityEngine;

public class PlanetInformation : MonoBehaviour
{
    public Planet Information;
}

public class Universe : MonoBehaviour
{
    public string FileLocation;
    public Mesh Mesh;
    public Material Material;
    [HideInInspector]
    public Planets Planets;

    public void Awake()
    {
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        sw.Start();
        if (File.Exists(FileLocation))
        {
            string contents = File.ReadAllText(FileLocation);
            Planets = JsonUtility.FromJson<Planets>(contents);
            sw.Stop();
            Debug.Log(sw.ElapsedMilliseconds);
        }
        for (int i = 0; i < Planets.Count; i++)
        {
            GameObject planet = new GameObject(Planets[i].Name);
            planet.AddComponent<MeshFilter>().sharedMesh = Mesh;
            planet.AddComponent<MeshRenderer>().sharedMaterial = Material;
            planet.AddComponent<PlanetInformation>().Information = Planets[i];
            planet.transform.SetParent(transform);
            planet.transform.position = Planets[i].PcDistance * PolarToCartesian(new Vector2(Planets[i].Declination, Planets[i].RightAscension)) * 5;
            planet.transform.localScale = Vector3.one * Planets[i].Radius;
        }
    }

    Vector3 PolarToCartesian(Vector2 polar)
    {
        //an origin vector, representing lat,lon of 0,0. 
        Vector3 origin = new Vector3(0, 0, 1);
        //build a quaternion using euler angles for lat,lon
        Quaternion rotation = Quaternion.Euler(polar.x, polar.y, 0);
        //transform our reference vector by the rotation. Easy-peasy!
        Vector3 point = rotation * origin;
        return point;
    }
}
