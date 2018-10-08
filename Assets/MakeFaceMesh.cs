using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeFaceMesh : MeshLifeForm {

  public LoadFaceMesh face;
  public Mesh mesh;
  public string name;

  public Material FaceMaterial;


  // Use this for initialization
  public override void Create(){

    MeshFilter m = gameObject.AddComponent<MeshFilter>();
    mesh = face.Load(name);
    ((MutatingVerts)verts).mesh = mesh;
    m.mesh = mesh;
    MeshRenderer r = gameObject.AddComponent<MeshRenderer>();
    r.material = FaceMaterial;

    Forms.Add(verts);
    Forms.Add(tris);

    verts._Create(verts);
    tris._Create(tris);
  }

 public override void OnGestate(){

    verts._OnGestate(verts );
    tris._OnGestate( tris   );
  }
  
  public override void WhileLiving(float v){

    verts.Mutate();
    tris.Mutate();
  }
	
	// Update is called once per frame
	void Update () {
    verts._WhileLiving();
		
	}
}
