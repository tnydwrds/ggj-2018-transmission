using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDepot : MonoBehaviour {

    [SerializeField]
    private GameObject projectile;

    public GameObject GetProjectileGameObject() {
        return projectile;
    }

}
