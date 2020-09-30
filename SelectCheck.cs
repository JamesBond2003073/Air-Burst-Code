using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCheck : MonoBehaviour
{ public int selectFlag = 0;
  public Vector3 refPos;
  public float refRotX;
  public Vector3 targetPosition;
  public float smoothTime = 20f;
  public float smoothTimeRot = 20f;
  public float tiltX;
  public GameObject newItemTut;
  public GameObject sphereTyre;
  public Rigidbody rb;

  void OnMouseDown()
  {
      selectFlag = 1;
      newItemTut.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("end",true);
          newItemTut.transform.GetChild(1).gameObject.GetComponent<Animator>().SetBool("end",true);
           sphereTyre.SetActive(true);
  }

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector3(-0.14f,0.6f,-0.26f);
        tiltX = -44f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        if(selectFlag == 1)
        {   
            tiltX = Mathf.SmoothDamp(tiltX,0f,ref refRotX , smoothTimeRot * Time.deltaTime);

            transform.position = Vector3.SmoothDamp(transform.position,targetPosition,ref refPos, smoothTime * Time.deltaTime);
            transform.rotation = Quaternion.Euler(tiltX,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z);
        }
        if(transform.rotation.eulerAngles.x <= 0.05f)
        selectFlag = 0;
        Debug.Log(selectFlag);
    }
}
