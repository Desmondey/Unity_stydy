using UnityEngine;

public class CircleRange : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    private float rez;
    private Vector2 newVector;
    [SerializeField] private float _speed;

    private void Update()
    {
        newVector = new Vector2(transform.position.x + 3, transform.position.y + 3).normalized;
        rez = obj.transform.position.magnitude - transform.position.magnitude;
        if (rez < 3)
        {
            print(1);
        }

    }
}
