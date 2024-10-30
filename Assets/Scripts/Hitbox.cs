using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public AttackID attackInfo;

    //This should be customizable when it is instantiated
    //A scriptable object could be used to set everything needed for the hitbox
    public Vector3 knockback;

    public AudioSource sound; 
    public AudioClip clip;

    public LayerMask layerMask;

    float elapsedTimeTillDestroy;

    private void OnTriggerEnter(Collider other) 
    {
        if (layerMask == (layerMask | (1 << other.transform.gameObject.layer)))
        {
            Hurtbox h = other.GetComponent<Hurtbox>();

            if (h != null)
            {
                OnHit(h);
            }
        }

    }

    protected void OnHit(Hurtbox h)
    {
        h.player.TakeDamage(attackInfo.damage);
        knockback = attackInfo.CalculateKnockback(gameObject.transform);
        h.player.movementScript.TakeKnockback(knockback);
        //InflictStun(attackInfo.stunDuration);
    }

    private void Update() {
        DestroyTimer();
    }

    protected void DestroyTimer()
    {
        elapsedTimeTillDestroy += Time.deltaTime;
        if (elapsedTimeTillDestroy >= attackInfo.attackLength)
        {
            Destroy(gameObject);
        }
    }

    //bool CheckForSameTeamLayer(Collider collider)
    //{
    //    return gameObject.layer == collider.transform.gameObject.layer ? true : false;
    //}
}
