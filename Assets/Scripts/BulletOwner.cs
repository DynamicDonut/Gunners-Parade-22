using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOwner : MonoBehaviour
{
    public int power = 1;
    public float speed;
    public Ray2D bulletDirection;

    void Awake() {
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x += bulletDirection.direction.x * speed * Time.deltaTime;
        currentPosition.y += bulletDirection.direction.y * speed * Time.deltaTime;
        transform.position = currentPosition;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(this.gameObject);
    }

    private void OnBecameInvisible() {
        Destroy(this.gameObject);
    }
}
