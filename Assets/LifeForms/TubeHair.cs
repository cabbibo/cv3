
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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
    Lifes.Add( HairTransfer);

    Forms.Add( Base );
    Forms.Add( Hair );
    Forms.Add( TubeVerts );
    Forms.Add( TubeTriangles );


    SetHairPosition._Create();
    HairCollision._Create();
    HairConstraint0._Create();
    HairConstraint1._Create();

    Base._Create( Base );
    Hair._Create( Base );


    HairTransfer._Create();
    TubeVerts._Create( Hair );
    TubeTriangles._Create( TubeVerts );



    SetHairPosition.BindPrimaryForm("_VertBuffer", Hair);
    SetHairPosition.BindForm("_BaseBuffer", Base );

    HairCollision.BindPrimaryForm("_VertBuffer", Hair);
    HairCollision.BindForm("_BaseBuffer", Base ); 

    HairConstraint0.BindInt("_Pass" , 0 );
    HairConstraint0.BindPrimaryForm("_VertBuffer", Hair);

    HairConstraint1.BindInt("_Pass" , 1 );
    HairConstraint1.BindPrimaryForm("_VertBuffer", Hair);

    HairTransfer.BindPrimaryForm("_VertBuffer", TubeVerts );
    HairTransfer.BindForm("_HairBuffer", Hair);

    HairTransfer.BindAttribute( "_TubeWidth" , "int" , "width" , TubeVerts );
    HairTransfer.BindAttribute( "_TubeLength" , "int" , "length" , TubeVerts );
    HairTransfer.BindAttribute( "_NumVertsPerHair" , "int" , "numVertsPerHair", Hair );

    SetHairPosition.BindAttribute( "_HairLength" , "float" , "length", Hair );
    SetHairPosition.BindAttribute( "_NumVertsPerHair" , "int" , "numVertsPerHair", Hair );

    // Don't need to bind for all of them ( constraints ) because same shader
    HairCollision.BindAttribute( "_HairLength" , "float" , "length", Hair );
    HairCollision.BindAttribute( "_NumVertsPerHair" , "int" , "numVertsPerHair", Hair );

  }

  public override void OnGestate(){

    Base._OnGestate( Base );
    Hair._OnGestate( Base );

    TubeTriangles._OnGestate( Hair );
    TubeVerts._OnGestate( Hair );

    body._Create( TubeVerts , TubeTriangles);
    //TubeTriangles.OnGestate( Hair );
    //TubeVerts.OnGestate( Hair );

  }


  public override void OnBirth(){
    SetHairPosition.Live();
    body.Show();
  }

  public override void WhileLiving(float v){

    HairCollision.shader.SetFloat("_HairLength", Hair.length ); 
    HairCollision.shader.SetInt("_NumVertsPerHair", Hair.numVertsPerHair); 
    HairCollision.Live();
    HairConstraint0.Live();
    HairConstraint1.Live();
    HairTransfer.Live();

    body.WhileLiving(1);


  }

  public override void WhileDebug(){
    Base.WhileDebug();
  }

}