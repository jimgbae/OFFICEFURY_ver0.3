using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Movement : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public Transform upperBody;
    public Animator _animator;

    public float speed = 10f;
    public float rotateSpeed = 5f;
    public float maxRotationAngle = 90f;

    [SerializeField] Vector3 RotPos = Vector3.zero;
    //public Quaternion upperBodyTargetRotation; 애니메이션 제작 된 후 사용 예정
    // Start is called before the first frame update
    void Start()
    {
        //_controller = this.GetComponent<CharacterController>();
        _rigidbody = this.GetComponent<Rigidbody>();
        _animator = this.GetComponent<Animator>();
        //upperBodyTargetRotation = upperBody.rotation;
    }

    void LateUpdate()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        CharacterRotate();
        CharacterMove();
    }

    private void CharacterMove()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");
        // -1 ~ 1

        Vector3 velocity = new Vector3(inputX, 0, inputZ).normalized * speed;

        _rigidbody.velocity = velocity;
    }

    private void CharacterRotate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (groundPlane.Raycast(ray, out rayLength))
        {
            Vector3 pointToLook = ray.GetPoint(rayLength);
            Vector3 lookDirection = pointToLook - transform.position;
            lookDirection.y = 0; // y-축 회전 방지
            lookDirection.Normalize(); // 방향 벡터를 정규화

            if (lookDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                targetRotation.eulerAngles = new Vector3(0, targetRotation.eulerAngles.y, 0); // x-축 회전 고정
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            }
        }
    }

}
