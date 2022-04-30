using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class RadioactiveZone : MonoBehaviour
{
    [Range(0.5f, 2f)]
    public float strength = 1;

    private SphereCollider col;

    void Start()
    {
        col = GetComponent<SphereCollider>();
        col.isTrigger = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();

            float dist = Vector3.Distance(col.transform.position, player.transform.position);
            float invdist = col.radius - dist;
            float normalized = Mathf.Clamp01(invdist / col.radius * 2);
            float radiation = normalized * strength;

            player.SetRadiation(radiation);
        }
    }

    private void OnDrawGizmos()
    {
        col = GetComponent<SphereCollider>();

        var deathCol = Color.red;
        var warningCol = new Color(1,.5f,0,.5f);
        deathCol.a = .5f;

        Gizmos.color = warningCol;
        Gizmos.DrawSphere(transform.position, col.radius);

        float deathDist = col.radius - col.radius / strength;
        Gizmos.color = deathCol;
        Gizmos.DrawSphere(transform.position, deathDist > 0 ? deathDist : 0);
    }
}
