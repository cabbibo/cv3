using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {


  [HideInInspector] public MeshRenderer render;
  [HideInInspector] public Mesh mesh;
  
  public Material material;
  public Form triangles;
  public Form verts;

  public void Create( Form triangles , Form verts ){

    material = new Material(material);
    mesh = new Mesh ();
    mesh.vertices = new Vector3[verts.count];
    mesh.triangles =  triangles.GetData<int>();
    mesh.bounds = new Bounds (Vector3.zero, Vector3.one * 1000f);
    mesh.UploadMeshData (true);

    GameObject go = new GameObject();
    go.name = gameObject.name + " : BODY";
    go.transform.parent = gameObject.transform;
    go.AddComponent<MeshFilter>().sharedMesh = mesh;

    render = go.AddComponent<MeshRenderer>();
    render.enabled = false;

  }

  public void Hide(){
    render.enabled = false;
  }

  public void Show(){
    if( triangles._buffer != null && verts._buffer != null ){
      render.material.SetInt("_TransferCount", verts.count);
      render.material.SetBuffer("_TransferBuffer", verts._buffer );
      render.enabled= true;
    }else{
      print("u got a null buffer! add more info to me to know which one");
    }
  }


}
