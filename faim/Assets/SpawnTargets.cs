using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTargets : MonoBehaviour
{
    public GameObject targetPrefab;

    // Start is called before the first frame update
    void Start()
    {
        CreateNewTarget();
    }

    void CreateNewTarget()
    {
        var bounds = new Bounds(this.transform.position, this.transform.localScale);
        var point = RandomPointInBounds(bounds);
        var target = Instantiate(targetPrefab, point, Quaternion.identity);
        var hittable = target.GetComponent<OnHittable>();
        hittable.OnHit += (_) =>
        {
            Destroy(target);
            CreateNewTarget();
        };
    }

    // Update is called once per frame
    void Update()
    {

    }

    private static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );

    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1f, 0, 0.5f);
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
#endif
}
