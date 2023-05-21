using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyController : MonoBehaviour
{
    [HideInInspector] public Transform Target;
    protected bool _isReadyToAttack = false;
}
