using UnityEngine;

public class BolletPlayer : MonoBehaviour
{
    [HideInInspector] public float BolletDamage;
    [SerializeField] private LayerMask _enemyBlueLayers;
    [SerializeField] private LayerMask _enemyRedLayers;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == _enemyBlueLayers)
        {
            Debug.Log(0);
        }
        else if(collision.gameObject.layer == _enemyRedLayers)
        {
            Debug.Log(1);
        }
    }
}
