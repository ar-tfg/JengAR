using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 0.02f;
    private float scrollSpeed = 1f;
    private float distance;
    private bool dragging = false;
    private GameObject selectedBlock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            transform.position += moveSpeed * new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            transform.position += scrollSpeed * new Vector3(0, -Input.GetAxis("Mouse ScrollWheel"), 0);
        }
        if (Input.GetMouseButtonDown(0))
        {
            selectedBlock = null;
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("He disparado");
                RaycastHit hit;


                if (Physics.Raycast(transform.position, transform.forward * 100, out hit))
                {
                    if (hit.collider.gameObject.CompareTag("Jenga"))
                    {
                        selectedBlock = hit.collider.gameObject;
                        selectedBlock.transform.parent = transform;
                        selectedBlock.GetComponent<Rigidbody>().useGravity = false;
                        selectedBlock.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("uh");
            if (selectedBlock != null)
                selectedBlock.transform.parent = null;
                selectedBlock.GetComponent<Rigidbody>().useGravity = true;
                selectedBlock.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;


        }

        /*  if (Input.GetButtonDown("Fire1"))
          {
              Debug.Log("He disparado");
              RaycastHit hit;


              if (Physics.Raycast(transform.position, transform.forward * 100, out hit))
              {

                  if (hit.collider.gameObject.CompareTag("Jenga"))
                  {
                      Debug.Log(transform.forward * 10);

                      hit.collider.gameObject.GetComponent<Rigidbody>().velocity = (transform.forward * 5);
                  }
                  else
                  {
                      Debug.Log("He fallado");

                  }
                  // Do something with the object that was hit by the raycast.
              }
              else
              {
                  Debug.Log("He petado");

              }

          }*/



    }
  
}
