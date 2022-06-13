using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerControls playerControls;
    [SerializeField] private float speed;
    [SerializeField] private GameObject bullet;
    public Color myBulletColor;
    public int bulletSpeed;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable ()
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerControls.Main.Shoot.performed += _ => ShootBullet(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // Allow player to move on X & Y axis
       Vector2 movementInput =  playerControls.Main.Move.ReadValue<Vector2>();
       Vector3 currentPosition = transform.position;
       currentPosition.x += movementInput.x * speed * Time.deltaTime;
       currentPosition.y += movementInput.y * speed * Time.deltaTime;
       transform.position = currentPosition;
    }

    private void ShootBullet(Vector3 myPos){
        GameObject myBullet = Instantiate(bullet, myPos, Quaternion.identity);
        var myBulletScript = myBullet.GetComponent<BulletOwner>();
        //myBulletScript.power = 1;
        myBulletScript.bulletDirection = new Ray2D (myPos, transform.up);
        myBulletScript.speed = bulletSpeed;
        myBullet.GetComponent<SpriteRenderer>().color = myBulletColor;
    }
}
