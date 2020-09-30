using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBlow : MonoBehaviour
{
   public float refX;
   public float refY;
   public float refZ;
   public float smoothTime = 10f;
   public int blowFlag = 0;
   public static int airFlag = 0;
   public float blowTimer = 4f;
   public Material pumpMat;
   public Material obj2Mat;
   public GameObject pumpObj;
   public GameObject obj2;
   public Color matColor;
   public float refA;
   public float matSmoothTime = 10f;
   public float pipeSmoothTime = 10f;
   public Vector3 refPipePos;
   public GameObject lever;
   public GameObject splash;
   public GameObject newItemTut;
   public GameObject sphereTyre;
   public GameObject spherePump;
    // Start is called before the first frame update
    void Start()
    {   
       
       
    }
    void OnEnable()
    {
        if(lol.blowCount == 0)
         matColor = pumpMat.color;
         if(lol.blowCount == 1)
         matColor = obj2Mat.color;
    }

    // Update is called once per frame
    void Update()
    {   

        if(airFlag == 1 && lol.blowCount == 0)
       {  //  this.gameObject.GetComponent<SphereCollider>().enabled = false; 
            pumpObj.transform.localScale = new Vector3(Mathf.SmoothDamp(pumpObj.transform.localScale.x,1.7f,ref refX,smoothTime * Time.deltaTime),Mathf.SmoothDamp(pumpObj.transform.localScale.y,1.7f,ref refY,smoothTime * Time.deltaTime),Mathf.SmoothDamp(pumpObj.transform.localScale.z,1.7f,ref refZ,smoothTime * Time.deltaTime));
            pumpObj.transform.Translate(new Vector3 (0f,0f,0.15f * Time.deltaTime)); 
            RopeSpawn.firstPart.transform.Translate(0f,0.16f * Time.deltaTime,0.158f * Time.deltaTime);
       }
        if(airFlag == 1 && lol.blowCount == 1)
       {  //  this.gameObject.GetComponent<SphereCollider>().enabled = false; 
            obj2.transform.localScale = new Vector3(Mathf.SmoothDamp(obj2.transform.localScale.x,1.7f,ref refX,smoothTime * Time.deltaTime),Mathf.SmoothDamp(obj2.transform.localScale.y,1.7f,ref refY,smoothTime * Time.deltaTime),Mathf.SmoothDamp(obj2.transform.localScale.z,1.7f,ref refZ,smoothTime * Time.deltaTime));
            obj2.transform.Translate(new Vector3 (0f* Time.deltaTime,0.23f * Time.deltaTime,0f )); 
           // obj2.transform.localPosition = new Vector3(obj2.transform.localPosition.x,obj2.transform.localPosition.y,1.09f);
            RopeSpawn.firstPart.transform.Translate(0f,0.16f * Time.deltaTime,0.235f * Time.deltaTime);
           
       }

       if(lol.blowCount == 0)
        {
            if(pumpObj.transform.localScale.x > 1.65f && blowFlag == 0)
        {
            pumpObj.SetActive(false);
            
            GameObject.Find("PumpFrac").transform.GetChild(0).gameObject.SetActive(true);
            blowFlag = 1;
            splash.SetActive(true);
            
        }
        }
        if(lol.blowCount == 1)
        {
            if(obj2.transform.localScale.x > 1.65f && blowFlag == 0)
        {
            obj2.SetActive(false);
            
            GameObject.Find("TyreFrac").transform.GetChild(0).gameObject.SetActive(true);
            blowFlag = 1;
            //splash.SetActive(true);
            
        }
        }
        
        if(blowFlag == 1)
        {    RopeSpawn.firstPart.transform.localPosition = Vector3.SmoothDamp(RopeSpawn.firstPart.transform.localPosition,new Vector3(0f,-0.38f,0.7f),ref refPipePos , pipeSmoothTime * Time.deltaTime );
            blowTimer -= Time.deltaTime;
            if(blowTimer <= 0f)
            {   
              lever.GetComponent<Animator>().SetBool("up",true);
              lever.GetComponent<Animator>().SetBool("down",false);
                   if(lol.blowCount == 0)
               {   newItemTut.SetActive(true);

                   matColor.a = Mathf.SmoothDamp(matColor.a,0f,ref refA, matSmoothTime * Time.deltaTime);
                
                   pumpMat.color = matColor;

                    if(matColor.a <= 0.05f)
               {   
                   lol.blowCount++;
                  // Debug.Log(lol.blowCount);
                   GameObject.Find("PumpFrac").transform.GetChild(0).gameObject.SetActive(false);
                   matColor.a = 1f;
                   pumpMat.color = matColor;
                   ContactCheck.contactFlag = 0;
                   airFlag = 0;
                   splash.SetActive(false);
                   spherePump.SetActive(false);
                   GameObject.Find("Obj2ManagerParent").transform.GetChild(0).gameObject.SetActive(true);
                //  Debug.Log("air "+airFlag);   
                     this.gameObject.SetActive(false);
                     
               }

               }

                  if(lol.blowCount == 1)
               { 
                   matColor.a = Mathf.SmoothDamp(matColor.a,0f,ref refA, matSmoothTime * Time.deltaTime);
                
                   obj2Mat.color = matColor;

                    if(matColor.a <= 0.05f)
               {
                   lol.blowCount++;
                  // Debug.Log(lol.blowCount);
                  // GameObject.Find("TyreFrac").transform.GetChild(0).gameObject.SetActive(false);
                   matColor.a = 1f;
                   obj2Mat.color = matColor;
                   ContactCheck.contactFlag = 0;
                   airFlag = 0;
                   splash.SetActive(false);
                   
                 
                //  Debug.Log("air "+airFlag);   
                     this.gameObject.SetActive(false);
                     
               }

               }
                  
               

              
            }
        }
    }
}
