using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LifeForm : Cycle {

  [ HideInInspector ] public List<Life> BirthLives;
  [ HideInInspector ] public List<Life> AliveLives;
  [ HideInInspector ] public List<Life> DeathLives;

  [ HideInInspector ] public List<Form> Children;
  [ HideInInspector ] public List<Form> Parents;
  
  public void AddChild( Form form ){
    Children.Add(form);
  }

  public void AddParent( Form form ){
    Parents.Add(form);
  }

  public void AddBirthLife( Life life ){
      BirthLives.Add( life );
  }

  public void AddAliveLife( Life life ){
      AliveLives.Add( life );
  }

  public void AddDeathLife( Life life ){
      DeathLives.Add( life );
  }



}
