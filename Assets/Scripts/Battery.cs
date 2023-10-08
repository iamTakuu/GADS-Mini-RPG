using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Collider2D))]
public class Battery : MonoBehaviour
{

    [SerializeField] private float speed = 1f;
    [SerializeField] private float minForce = 0.2f;
    [SerializeField] private float maxForce = 0.5f;
    [SerializeField] private List<float> knockBackAngles;
    
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private bool _isMoving = true;
    private Collider2D _collider2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_isMoving)
        {
            // Move the battery left at a constant speed using the rigidbody
            _rigidbody2D.velocity = Vector2.left * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        _isMoving = false;
        var thisAng = CalculateAngle();
        _rigidbody2D.AddForce(new Vector2(thisAng.x, thisAng.y), ForceMode2D.Impulse);
        _rigidbody2D.SetRotation( Mathf.Atan2(thisAng.y, thisAng.x) * Mathf.Rad2Deg);
            
        // Disable the collider so the player can't pick it up
        _collider2D.enabled = false;
            
        _spriteRenderer
            .DOFade( 0, 0.5f)
            .OnComplete(() => Destroy(gameObject));
    }
    private (float x, float y) CalculateAngle()
    {
        // Get the angle of the battery
        var angle = knockBackAngles[Random.Range(0, knockBackAngles.Count)];
        var knockbackForce = Random.Range(minForce, maxForce);
        float x = Mathf.Cos(angle * Mathf.PI / 180) * knockbackForce;
        float y = Mathf.Sin(angle * Mathf.PI / 180) * knockbackForce;
        return (x, y);
    }
}
