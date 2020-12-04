using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    [SerializeField]
    private GameObject laserSprite;

    [SerializeField]
    private Animator laserAnim;

    private bool _weaponActive = true;

    private bool isEnemyLaser = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignEnemyLaser()
    {
        isEnemyLaser = true;
    }

}
