using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    // var for how much nyoom
    [SerializeField] private float speed;

    // var for adding nyoom
    [SerializeField] private float accel;
    [SerializeField] private float maxAccel;
    [SerializeField] private float maxReverse;

    //var for direction of nyoom
    private bool foward = true;

    // var for steering
    private Vector3 steering;

    private Rigidbody rbody;

    [SerializeField] carButton carButton;

    private void Awake()
    {
        if (rbody == null)
        {
            if(!TryGetComponent<Rigidbody>(out rbody))
            {
                Debug.Log("Need rigidbody bestie");
            }
        }
        accel = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        //sub to acceleration and deceleration
        carButton.changeAccelEvent += Accelerate;
        //sub to steering
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.forward * speed * accel * Time.deltaTime;
        move = move.normalized;
        rbody.velocity = move;
    }

    private void Accelerate(float _accel)
    {
        //change aaccel depend on currrenc tdir and accel
        Debug.Log("AAASASAAAAAAAA");
        accel += _accel;
        accel = Mathf.Clamp(accel, maxReverse, maxAccel);
    }
}
