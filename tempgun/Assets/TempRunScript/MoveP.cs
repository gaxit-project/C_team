using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveP : MonoBehaviour
{
    // �ړ����x
    [SerializeField] private Vector3 _velocity;
    bool flag=true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���x_velocity�ňړ�����i���[�J�����W�j
        
        if (flag)
        {
            transform.localPosition += _velocity * Time.deltaTime;
            if(transform.position.x > 5)
            {
                flag = false;
            }
        }
        if (!flag)
        {
            transform.localPosition += _velocity * Time.deltaTime * -1;
            if (transform.position.x < -5)
            {
                flag = true;
            }
        }

        //transform.localPosition += _velocity * Time.deltaTime;
    }
}
