using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCheck : MonoBehaviour
{  public GameObject leverTut;
    
  void OnMouseDown()
  { 
      if(ScaleBlow.airFlag == 0 && ContactCheck.contactFlag == 1)
     {    
          ScaleBlow.airFlag = 1;
          this.gameObject.GetComponent<Animator>().SetBool("down",true);
          this.gameObject.GetComponent<Animator>().SetBool("up",false);
          if(lol.blowCount == 0)
          {
          leverTut.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("end",true);
          leverTut.transform.GetChild(1).gameObject.GetComponent<Animator>().SetBool("end",true);
          }

     }
     else if( ScaleBlow.airFlag == 1 && ContactCheck.contactFlag == 1)
     {
          ScaleBlow.airFlag = 0;
          if(lol.blowCount == 0)
          {
          this.gameObject.GetComponent<Animator>().SetBool("up",true);
          this.gameObject.GetComponent<Animator>().SetBool("down",false);
          }
     }
  }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
