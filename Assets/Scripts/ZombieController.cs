using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.05f;
    [SerializeField] float rotSpeed = 10f;
    [SerializeField] float stoppingDistance = 0.1f;

    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var horiVectorToCamera = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z) - transform.position;
        var horiSqrMagToCamera = horiVectorToCamera.sqrMagnitude;

        if (horiSqrMagToCamera > stoppingDistance)
        {
            
            anim.SetBool("isRunning", true);
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);
            
            var targetRot = Quaternion.LookRotation(horiVectorToCamera, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
        }
        
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
