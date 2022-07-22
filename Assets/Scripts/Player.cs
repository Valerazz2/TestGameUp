using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float travelSpeed;
    private Camera camera;
    private bool watchRight = true;
    [SerializeField] private Animator Animator;
    private float offsetZ;
    void Start()
    {
        camera = Camera.main;
        offsetZ = gameObject.transform.position.z - camera.transform.position.z;
    }

    void Update()
    {
        Animator.SetBool("Run", false);
        if (Input.GetKey(KeyCode.W))
        {
            Animator.SetBool("Run", true);
            gameObject.transform.Translate(Vector3.up * Time.deltaTime * travelSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Animator.SetBool("Run", true);
            if (watchRight)
            {
                watchRight = false;
                var rot = gameObject.transform.localScale;
                rot.x *= -1;
                gameObject.transform.localScale = rot;
            }
            gameObject.transform.Translate(Vector3.left * Time.deltaTime * travelSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Animator.SetBool("Run", true);
            gameObject.transform.Translate(Vector3.down * Time.deltaTime* travelSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Animator.SetBool("Run", true);
            if (!watchRight)
            {
                watchRight = true;
                var rot = gameObject.transform.localScale;
                rot.x *= -1;
                gameObject.transform.localScale = rot;
            }
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * travelSpeed);
        }
        
        camera.transform.position = Vector3.Lerp(camera.transform.position, transform.position + Vector3.back * offsetZ, 0.01f);
    }
}
