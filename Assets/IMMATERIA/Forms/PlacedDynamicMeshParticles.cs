using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedDynamicMeshParticles: Particles {

  struct Vert{

  
    public Vector3 pos;
    public Vector3 vel;
    public Vector3 nor;
    public Vector3 tan;
    public Vector2 uv;
    public float used;
    public Vector3 triIDs;
    public Vector3 triWeights;
    public Vector3 debug;

  };

  public override void SetStructSize( Form parent ){ structSize = 24; }

}
