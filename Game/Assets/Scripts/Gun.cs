using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public Camera fpsCam;
    private Vector3 HIGHT_OFFSET = new Vector3(0, 0.67f, 0);
    public Vector3 gunPosition;
    private LineRenderer trace;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire) {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    private void Shoot() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + HIGHT_OFFSET, transform.forward, out hit, range)) {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null) {
                target.TakeDamage(damage);
            }
        }
    }
}
