using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpawn : MonoBehaviour
{
   [SerializeField]
   GameObject partPrefab,parentObject,lastPart;
   public static GameObject firstPart;

   [SerializeField]
   [Range(1,1000)]
   int length = 1;
  
   [SerializeField]
   float partDistance = 0.2f;

   [SerializeField]
   bool reset,spawn,snapFirst,snapLast,assignPos;

   public Vector3 mousePosition;
   public Vector2 direction;
    float horSpeed = 0.01f;
    float verSpeed = 0.01f; 
   public Mesh meshNozzle;
   public Material nozzleMat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
       if(ContactCheck.contactFlag == 1)
       {
           horSpeed = 5f;
           verSpeed = 5f;
       }
        if(ContactCheck.contactFlag == 0)
       {
           horSpeed = 23f;
           verSpeed = 23f;
       }

        if(reset)
        {
           foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Player"))
           {
               Destroy(tmp);
           }
        }
        if(spawn)
        {
            Spawn();
            spawn = false;
        }
        
        if(Input.GetMouseButton(0))
        {
           float h = horSpeed * Input.GetAxis("Mouse X");
           float v = verSpeed * Input.GetAxis("Mouse Y");

            firstPart.transform.Translate(0f,v * Time.deltaTime,h * Time.deltaTime);
        }
         firstPart.transform.localPosition = new Vector3(firstPart.transform.localPosition.x,Mathf.Clamp(firstPart.transform.localPosition.y,-0.4f,1.2f),Mathf.Clamp(firstPart.transform.localPosition.z,0f,1.4f));
       //  firstPart.transform.localPosition = new Vector3(firstPart.transform.localPosition.x,Mathf.Clamp(firstPart.transform.localPosition.y,-0.4f,1.2f),Mathf.Clamp(firstPart.transform.localPosition.z,0f,1.4f));
        
    }

    public void Spawn()
    {
        int count = (int)(length/partDistance);

        for(int x=0 ; x< count;x++)
        {
            GameObject tmp;
           tmp = Instantiate(partPrefab,new Vector3(transform.position.x ,transform.position.y ,transform.position.z + partDistance * (x+1)),Quaternion.identity,parentObject.transform);
           tmp.transform.eulerAngles = new Vector3(-90f,0f,0f);  
           tmp.name = parentObject.transform.childCount.ToString();
            if(x == 0)
            {   tmp.transform.eulerAngles = new Vector3(0f,0f,0f); 
                tmp.AddComponent<ContactCheck>();
                tmp.GetComponent<MeshRenderer>().material = nozzleMat; 
                 tmp.GetComponent<MeshFilter>().sharedMesh = meshNozzle;
                 tmp.transform.localScale = new Vector3(3.41f,5.2f,3.41f);
                 tmp.GetComponent<CapsuleCollider>().height = 0.03f;
                 tmp.GetComponent<CapsuleCollider>().radius = 0.035f;
                 tmp.GetComponent<CapsuleCollider>().center = new Vector3(0f,0f,-0.015f);
                 tmp.GetComponent<ContactCheck>().pipeTut = GameObject.Find("CanvasUI").transform.GetChild(1).transform.gameObject;
                 tmp.GetComponent<ContactCheck>().leverTut = GameObject.Find("CanvasUI").transform.GetChild(2).transform.gameObject;
                Destroy(tmp.GetComponent<CharacterJoint>());
                firstPart = tmp;
                if(snapFirst)
                {
                  //  tmp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                   tmp.GetComponent<Rigidbody>().isKinematic = true;
                }
            
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }
        }
        if(snapLast)
        {
           // parentObject.transform.Find(parentObject.transform.childCount.ToString()).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
           parentObject.transform.Find(parentObject.transform.childCount.ToString()).GetComponent<Rigidbody>().isKinematic = true;
         //  snapLast = false;
           
        }
        if(assignPos)
        {
             parentObject.transform.Find(parentObject.transform.childCount.ToString()).transform.localPosition += new Vector3(0f,0.35f,0f);
            parentObject.transform.GetChild(0).transform.localPosition += new Vector3(0f,-0.38f,1.1f);
            lastPart = parentObject.transform.Find(parentObject.transform.childCount.ToString()).gameObject;
             assignPos = false;
        }
    }

}
