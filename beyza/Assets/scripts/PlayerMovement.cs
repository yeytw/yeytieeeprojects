using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 700f;
    
    private float horizontal;
    private float vertical;

    public Animator animator;

    public bool playercanfish = true;
    public bool walking = false;
    public bool sellingstand = false;

   

    void Update()
    {
        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;

        if (movement.magnitude > 0)
        {
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            walking = true;
        }else
        { walking = false; }

        animator.SetBool("Walk", walking);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Lake"))
        {
            playercanfish = true;
        }

        if(other.CompareTag("Stands"))
        {
            sellingstand = true;
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Lake"))
        {
            playercanfish = false;
        }

        if(other.CompareTag("Stands"))
        { 
            sellingstand = false;
        }
    }





}
