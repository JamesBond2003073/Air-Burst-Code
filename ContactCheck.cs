using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactCheck : MonoBehaviour
{ 
    public static int contactFlag = 0;
    public GameObject pipeTut;
    public GameObject leverTut;

   void OnTriggerEnter(Collider other)
   {  if(lol.blowCount == 0)
   {
       if(other.gameObject.tag == "Pumpkin")
       {
             contactFlag = 1;
             pipeTut.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("end",true);
              pipeTut.transform.GetChild(1).gameObject.GetComponent<Animator>().SetBool("end",true);
              leverTut.SetActive(true);



       }
   }
   if(lol.blowCount == 1)
   {
       if(other.gameObject.tag == "Tyre")
       contactFlag = 1;
   }
   }
   void OnTriggerExit(Collider other)
   {  if(lol.blowCount == 0)
   {

       if(other.gameObject.tag == "Pumpkin")
       contactFlag = 0;
   }
    if(lol.blowCount == 1)
   {
       if(other.gameObject.tag == "Tyre")
       contactFlag = 0;
   }

   }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     //   Debug.Log(contactFlag);
    }
}
