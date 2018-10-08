using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceParticlesOnMesh : LifeForm {

  public Form particles;
    public Life place;
  public Life intersect;
  public Vector3 cameraUp;
  public Vector3 cameraLeft;
  public float radius;
  public float[] transformFloats;

  public int test;

  public TouchToRay touch;

  public MeshLifeForm skin;



  public ParticleTransferVerts bodyVerts;
  public ParticleTransferTris bodyTris;
  public Life bodyTransfer;
  public Body body;


  // Use this for initialization
  public override void Create(){

    Lifes.Add(intersect);
    Lifes.Add(place);
    Lifes.Add(bodyTransfer);
    Forms.Add(particles);
    Forms.Add(bodyVerts);
    Forms.Add(bodyTris);
    
    particles._Create(skin.verts);
    
    bodyVerts._Create(particles);
    bodyTris._Create(bodyVerts);


  place._Create();
    intersect._Create();
    bodyTransfer._Create();

    place.BindPrimaryForm("_VertBuffer",particles);
    place.BindForm("_SkinnedBuffer",skin.verts);
    place.BindAttribute("_Transform" , "transformFloats" , this );


    intersect.BindForm("_ParticleBuffer",particles);
    intersect.BindForm("_SkinnedVertBuffer",skin.verts);
    intersect.BindPrimaryForm("_SkinnedTriBuffer",skin.tris);
    intersect.BindAttribute("_RO"  , "RayOrigin" , touch );
    intersect.BindAttribute("_RD"  , "RayDirection" , touch );
    intersect.BindAttribute("_Transform" , "transformFloats" , this );

    bodyTransfer.BindAttribute("_CameraUp" , "cameraUp" , this );
    bodyTransfer.BindAttribute("_CameraLeft" , "cameraLeft" , this );
    bodyTransfer.BindAttribute("_Radius" , "radius" , this );

    bodyTransfer.BindPrimaryForm("_VertBuffer", bodyVerts);
    bodyTransfer.BindForm("_ParticleBuffer", particles); 
    

 

  }


  public override void OnGestate(){
    particles._OnGestate(particles );
    bodyTris._OnGestate( particles );
    bodyVerts._OnGestate( particles );
    body._Create( bodyVerts , bodyTris );
  }
  public override void OnBirth(){
    body.Show();
  }

  public override void WhileLiving(float v){


//    print(Camera.main);
    cameraLeft = -Camera.main.transform.right;
    cameraUp = Camera.main.transform.up;
    transformFloats = HELP.GetMatrixFloats(transform.localToWorldMatrix);

    place.Live();
    intersect.Live();
    bodyTransfer.Live();
    body.WhileLiving(1);
  }

}



