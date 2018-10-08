using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutatingVerts : Form {

  public Mesh mesh;
  
  struct Vert{
    public Vector3 pos;
    public Vector3 nor;
    public Vector2 uv;
    public float debug;
  };

  public override void SetStructSize( Form parent ){ structSize = 9; }

  public override void SetCount( Form parent ){ 
    count = mesh.vertices.Length;
  }

public override void Embody(Form parent){
  WhileMutate();
}

public override void Mutate(){
  WhileMutate();
}

  void WhileMutate(){


    Vector3[] verts = mesh.vertices;
    Vector2[] uvs = mesh.uv;
    Vector3[] nors = mesh.normals;

    int index = 0;


    Vector3 pos;
    Vector3 uv;
    Vector3 nor;
    int baseTri;

    float[] values = new float[count*structSize];
    for( int i = 0; i < count; i ++ ){
      values[ index ++ ] = verts[i].x;
      values[ index ++ ] = verts[i].y;
      values[ index ++ ] = verts[i].z;

      values[ index ++ ] = nors[i].x;
      values[ index ++ ] = nors[i].y;
      values[ index ++ ] = nors[i].z;

      values[ index ++ ] = uvs[i].x;
      values[ index ++ ] = uvs[i].y;

      values[ index ++ ] = (float)i/(float)count;
    }
    SetData( values );
  }
}