using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LifeForm : Cycle {

  public bool Active;
  
[ HideInInspector ] public List<Life> Lifes;
[ HideInInspector ] public List<Form> Forms;


public override void _Destroy(){
  
  foreach( Form f in Forms ){
    f._Destroy();
  }
  foreach( Life l in Lifes ){
    l._Destroy();
  }
  
}

public virtual void Activate(){}
public virtual void Deactivate(){}
  





}
