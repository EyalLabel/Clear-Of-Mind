using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject laserPrefab;
    public float projectileSpeed = 10;
    public float timeBetweenShooting, reloadTime, timeBetweenShots;
    public GameObject playerCamera;
    bool shooting, readyToShoot;
    bool allowInvoke = true;


    private void Awake()
    {
        readyToShoot = true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootInput();
    }

    private void ShootInput()
    {
        shooting = Input.GetKeyDown(KeyCode.Mouse0);
        if (readyToShoot && shooting )
        {
            Shoot();
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
           
        }
       
    }

    private void Shoot()
    {
        readyToShoot = false;

        Transform shootrotation = spawnPoint;
        Camera camera = playerCamera.GetComponent<Camera>();


        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit)) targetPoint = hit.point;
        else targetPoint = ray.GetPoint(75);
        Vector3 direction = targetPoint - spawnPoint.position;
        
        GameObject laser = Instantiate(laserPrefab, spawnPoint.position, laserPrefab.transform.rotation);

        laser.transform.forward = direction.normalized;

        laser.GetComponent<Rigidbody>().AddForce(direction.normalized * projectileSpeed, ForceMode.Impulse);
    

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }
    }

    private void ResetShot()
    {
        allowInvoke = true;
        readyToShoot = true;
    }
}
