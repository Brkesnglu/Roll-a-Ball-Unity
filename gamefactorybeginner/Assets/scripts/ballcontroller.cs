using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ballcontroller : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed =1f;

    [SerializeField]
    private float _jumpSpeed =1f;

    private Rigidbody _rigidbody;

    private bool _isGrounded;
    private bool iscollectible;
    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        CheckInput();
    }
    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.left);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.back);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _rigidbody.AddForce(Vector3.right * 7, ForceMode.Acceleration);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(0);
        }
    }
    private void Jump()
    {
        if (!_isGrounded)
        {
            return;
        }
        _rigidbody.AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);
    }
    private void Move(Vector3 direction)
    {
        _rigidbody.AddForce(direction * _moveSpeed, ForceMode.Acceleration);
    }
    private void OnCollisionEnter(Collision other)
    {
        _isGrounded = true;
        
        CheckEnemyCollision(other);
    }

    private void CheckEnemyCollision(Collision collision)
    {
        bool hasCollidedWithEnemy = collision.collider.GetComponent<enemy>();
        if (!hasCollidedWithEnemy)
        {
            return;
        }
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity))
        {
            enemy enemys = hit.collider.GetComponent<enemy>();
            bool isOnTopOfEnemy = enemys != null;
            if (isOnTopOfEnemy)
            {
                enemys.Die();
                return;
            }
        }
        Die();
    }

    private void OnCollisionExit(Collision other)
    {
        _isGrounded = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        collectible collectibles = other.GetComponent<collectible>();
        bool isCollectible = collectibles != null;
        if (isCollectible)
        {
            collectibles.Collect();
        }
    }
    private void Die()
    {
        FindObjectOfType<LevelManager>().RestartScene();
        GetComponent<MeshRenderer>().enabled = false;
        
    }
    
}
