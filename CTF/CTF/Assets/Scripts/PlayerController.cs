using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed; // Movement speed in units per second
    public float jumpForce; // Force applied upwards
    public int curHp;
    public int maxHp;

    [Header("Camera")]
    public float lookSensitivity; // Mouse look sensitivity
    public float maxLookX; // Lowest down we can look
    public float minLookX; // Highest up we can look
    // Private variables 
    private float rotX; // Current x rotation of the camera
    private Camera camera;
    private Rigidbody rb;
    // private Weapon weapon;

    void Awake()
    {
        // weapon = GetComponent<Weapon>();
        curHp = maxHp;
    } 

    // Start is called before the first frame update
    void Start()
    {
        // Get componenets
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();

        /* Initialize the UI
        GameUI.instance.UpdateHealthBar(curHp, maxHp);
        GameUI.instance.UpdateScoreText(0);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
        */
    }

    //Applies damage to the player
    public void TakeDamage(int damage)
    {
        curHp -= damage;
        
        if(curHp <= 0)
            Die();

        // GameUI.instance.UpdateHealthBar(curHp, maxHp);
    }

    void Die()
    {
        // GameManager.instance.LoseGame();
        Debug.Log("Player has died! Game over!");
        Time.timeScale = 0;
    }

    public void GiveHealth(int amountToGive)
    {
        // curHp = Mathf.Clamp(curHp + amountToGive, 0, maxHp);
        // GameUI.instance.UpdateHealthBar(curHp, maxHp);
        Debug.Log("Player has been healed!");
    }

    public void GiveAmmo(int amountToGive)
    {
        // weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
        // GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
        Debug.Log("Player has collected ammo!");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraLook();

        /*
        // Fire button
        if(Input.GetButton("Fire1"))
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }
        */

        // Jump button
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        /*
        // Don't do anything if the game is paused
        if(GameManager.instance.gamePaused == true)
            return;
        */
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed; // Getting input for left and right movement
        float z = Input.GetAxis("Vertical") * moveSpeed; // Getting input for forward and back movement

        // Walk in the direction you're looking/facing
        Vector3 dir = (transform.right * x) + (transform.forward * z);
        dir.y = rb.velocity.y;
        rb.velocity = dir; // Drives movement relative to the camera's look direction
    }

    void CameraLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity; // Look up and down (contrary to what you would think)
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity; // Look left and right
        
        // Restrict rotation on the x-axis between maxLookX to minLookX
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

        // Drives camera rotation
        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
