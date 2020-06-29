using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    #region Variables
    [SerializeField]private Torpedo[] Torpedos;
    [SerializeField] private Transform SpawnPoint_L;
    [SerializeField] private Transform SpawnPoint_R;
    [SerializeField] private float ReloadTimer = 10f;

    private bool Reloading = false;
    public Transform Target { get; set; }
    public int AmmoCount { get; set; }
    public UnityEvent Fired;
    public UnityEvent Reloaded;
    #endregion

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Torpedos.Length != 0 && !Reloading) FireWeapons();
        }
    }

    #region Functions
    private void FireWeapons()
    {
        foreach (Torpedo _T in Torpedos)
        {
            if (_T._Active == false)
            {
                _T.Activate();
            }
        }
        Fired.Invoke();
        StartCoroutine("Reload");
    }

    IEnumerator Reload()
    {
        Reloading = true;
        while(true)
        {
            yield return new WaitForSeconds(ReloadTimer);
            ResetTorpedos();
            Reloading = false;
            Reloaded.Invoke();
            yield break;

        }
    }
    private void ResetTorpedos()
    {
        Torpedos[0].transform.parent = this.transform;
        Torpedos[0].transform.position = SpawnPoint_L.position;
        Torpedos[1].transform.parent = this.transform;
        Torpedos[1].transform.position = SpawnPoint_R.position;
        foreach (Torpedo _Torp in Torpedos)
        {
            _Torp.DeActivate();
            _Torp.transform.localRotation = Quaternion.identity;
        }
    }
    #endregion

}
