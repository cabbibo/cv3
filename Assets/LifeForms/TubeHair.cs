
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeHair : LifeForm {

  public Life SetHairPosition;
  public Life HairCollision;
  
  public ConstraintLife HairConstraint0;
  public ConstraintLife HairConstraint1;

  public Life HairTransfer;

  public Form Base;
  public Form Hair;
  public TubeTriangles TubeTriangles;
  public TubeVerts TubeVerts;

  public Body body;

  public override void Create(){

    /*  
      All of this info should be visualizable!
    */

    SetHairPosition.Create();
    HairCollision.Create();
    HairConstraint0.Create();
    HairConstraint1.Create();
    HairTransfer.Create();

    Base.Create( Base );
    Hair.Create( Base );
    TubeTriangles.Create( Hair );
    TubeVerts.Create( Hair );

    body.Create( TubeVerts, TubeTriangles);



    SetHairPosition.BindPrimaryForm("_VertBuffer", Hair);
    SetHairPosition.BindForm("_BaseBuffer", Base );

    HairCollision.BindPrimaryForm("_VertBuffer", Hair);
    HairCollision.BindForm("_BaseBuffer", Base );

    HairConstraint0.BindInt("_Pass" , 0 );
    HairConstraint0.BindPrimaryForm("_VertBuffer", Hair);

    HairConstraint1.BindInt("_Pass" , 1 );
    HairConstraint1.BindPrimaryForm("_VertBuffer", Hair);

    HairTransfer.BindPrimaryForm("_HairBuffer", Hair);
    HairTransfer.BindForm("_HairBuffer", Hair);

  }

  public override void OnGestate(){

    Base.OnGestate( Base );
    Hair.OnGestate( Base );
    TubeTriangles.OnGestate( Hair );
    TubeVerts.OnGestate( Hair );

  }


  public override void OnBirth(){
    SetHairPosition.Live();
    body.Show();
  }

  public override void WhileAlive(float v){

    HairCollision.Live();
    HairConstraint0.Live();
    HairConstraint1.Live();
    HairTransfer.Live();

  }


}