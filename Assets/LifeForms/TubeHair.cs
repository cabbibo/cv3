
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeHair : LifeForm {

  public Life SetHairPosition;
  public Life HairCollision;
  
  public ConstraintLife HairConstraint0;
  public ConstraintLife HairConstraint1;


  public Form Base;
  public Hair Hair;
 



  public Life HairTransfer;

  public TubeTriangles TubeTriangles;
  public TubeVerts TubeVerts;

  public Body body;

  public override void Create(){

    /*  
      All of this info should be visualizable!
    */

    Lifes.Add( SetHairPosition );
    Lifes.Add( HairCollision );
    Lifes.Add( HairConstraint0 );
    Lifes.Add( HairConstraint1 );

    Forms.Add( Base );
    Forms.Add( Hair );


    SetHairPosition._Create();
    HairCollision._Create();
    HairConstraint0._Create();
    HairConstraint1._Create();

    Base._Create( Base );
    Hair._Create( Base );

    print( Base.["count"]);



    //HairTransfer.Create();
    //TubeTriangles.Create( Hair );
    //TubeVerts.Create( Hair );
    //body.Create( TubeVerts, TubeTriangles);



    SetHairPosition.BindPrimaryForm("_VertBuffer", Hair);
    SetHairPosition.BindForm("_BaseBuffer", Base );

    HairCollision.BindPrimaryForm("_VertBuffer", Hair);
    HairCollision.BindForm("_BaseBuffer", Base ); 

    HairConstraint0.BindInt("_Pass" , 0 );
    HairConstraint0.BindPrimaryForm("_VertBuffer", Hair);

    HairConstraint1.BindInt("_Pass" , 1 );
    HairConstraint1.BindPrimaryForm("_VertBuffer", Hair);

    //HairTransfer.BindPrimaryForm("_HairBuffer", Hair);
    //HairTransfer.BindForm("_HairBuffer", Hair);

  }

  public override void OnGestate(){

    Base._OnGestate( Base );
    Hair._OnGestate( Base );
    //TubeTriangles.OnGestate( Hair );
    //TubeVerts.OnGestate( Hair );

  }


  public override void OnBirth(){
    print("birth");
    SetHairPosition.shader.SetFloat("_HairLength", Hair.length ); 
    SetHairPosition.shader.SetInt("_NumVertsPerHair", Hair.numVertsPerHair); 
    SetHairPosition.Live();
    //body.Show();
  }

  public override void WhileLiving(float v){



   HairCollision.shader.SetFloat("_HairLength", Hair.length ); 
   HairCollision.shader.SetInt("_NumVertsPerHair", Hair.numVertsPerHair); 
   HairCollision.Live();
   HairConstraint0.Live();
   HairConstraint1.Live();
    //HairTransfer.Live();

  }

  public override void WhileDebug(){
    Base.WhileDebug();
  }

}