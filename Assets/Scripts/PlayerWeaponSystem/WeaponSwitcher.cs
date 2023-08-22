using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class WeaponSwitcher : MonoBehaviour
{
    public int selectedWeapon = 0;
    
    void Start()
    {
        SelectWeapon();
    }

    
    void Update()
    {
        SwitchWeapon();
    }

    private void SwitchWeapon()
    {
        int prevSelectWeapon = selectedWeapon;
        if (Input.GetKeyDown(KeyCode.Mouse2))//> 0f
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else selectedWeapon++;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))//
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else selectedWeapon--;
        }

        if (prevSelectWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                weapon.gameObject.GetComponent<PlayerWeapon>().setIsActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
                weapon.gameObject.GetComponent<PlayerWeapon>().setIsActive(false);

            }
            i++;
        }
    }

     public void AddWeapon( Collision weapon)
    {
        GameObject temp;
        Debug.Log("AddWeapon!");
        temp = Instantiate(weapon.gameObject, transform.position, transform.rotation);
        temp.gameObject.transform.SetParent(transform);
        temp.transform.localPosition = Vector3.zero;
        temp.transform.localRotation = Quaternion.Euler(Vector3.zero);
        temp.transform.localScale = Vector3.one;
        temp.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        temp.gameObject.SetActive(false);

    }
}
