using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidBody;
    [SerializeField] float _moveSpeed = 2f;
    [SerializeField] float _limitSpeed = 10f;
    [SerializeField] GameObject _goal;
    bool isStop = false;
    
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO
        //移動せよ
        //ゴールに着いたら止める
        if (isStop)
        {
            if (_rigidBody.velocity != Vector3.zero)
                _rigidBody.velocity = Vector3.zero;
            return;
        }
            
        //ゴールを超えたら止まる
        if(_goal.transform.position.z <= this.transform.position.z)
        {
            isStop = true;
            _rigidBody.velocity = Vector3.zero;
        }

        //速度制限
        if (_rigidBody.velocity.magnitude > _limitSpeed)
            _rigidBody.velocity = _rigidBody.velocity.normalized * _limitSpeed;
        else
            _rigidBody.AddForce(new Vector3(0, 0, 10f) * _moveSpeed);

    }
}