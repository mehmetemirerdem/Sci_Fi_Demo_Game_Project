using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField]
    private float speed = 3.5f;
    private float gravity = 9.81f;

    [SerializeField]
    private GameObject muzzleFlash;

    [SerializeField]
    private GameObject hitMarkerPrefab;

    [SerializeField]
    private AudioSource weaponAudio;

    private int currentAmmo;
    private int maxAmmo = 50;
    private bool isReloading = false;

    private UIManager_sc uiManager_sc;

    public bool hasCoin = false;

    [SerializeField]
    private GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        currentAmmo = maxAmmo;

        hitMarkerPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        uiManager_sc = GameObject.Find("Canvas").GetComponent<UIManager_sc>();
        if (uiManager_sc == null)
        {
            Debug.LogError("UI Manager is NULL");
        }

        if (Input.GetMouseButton(0) && currentAmmo > 0)
        {
            Shoot();
        }
        else
        {
            muzzleFlash.SetActive(false);
            weaponAudio.Stop();
        }

        if (Input.GetKeyDown(KeyCode.R) && isReloading == false)
        {
            isReloading = true;
            StartCoroutine(Reload());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        CalculateMovement();
    }

    public void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * speed;
        velocity.y -= gravity;

        velocity = transform.transform.TransformDirection(velocity);
        controller.Move(velocity * Time.deltaTime);
    }

    private void Shoot()
    {
        muzzleFlash.SetActive(true);
        currentAmmo--;
        uiManager_sc.UpdateAmmo(currentAmmo);
        if (weaponAudio.isPlaying == false)
        {
            weaponAudio.Play();
        }

        Vector3 centerOfTheView = new Vector3(0.5f, 0.5f, 0);
        Ray rayOrigin = Camera.main.ViewportPointToRay(centerOfTheView);
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            Debug.Log("Raycast hit: " + hitInfo.transform.name);
            GameObject hitmarker = Instantiate(hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(hitmarker, 1f);

            Destructible_sc destructible_sc = hitInfo.transform.GetComponent<Destructible_sc>();
            if (destructible_sc != null)
            {
                destructible_sc.DestroyCrate();
            }
        }
    }
    public void EnableWeapon()
    {
        weapon.SetActive(true);
        hitMarkerPrefab.SetActive(true);
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1.5f);
        currentAmmo = maxAmmo;
        uiManager_sc.UpdateAmmo(currentAmmo);
        isReloading = false;
    }
}
