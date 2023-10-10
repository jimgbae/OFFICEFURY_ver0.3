using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class FollowCam : MonoBehaviour
{
    public Vector3 CamRotation;
    public Vector3 CamPoision;

    [SerializeField] Transform target = null;
    [SerializeField] Camera _cam;
    [SerializeField] float TargetDistance = 400f;
    [SerializeField] float MaxRangeDistance = 1000f;
    [SerializeField] float Range = 3f;
    [SerializeField] float Speed = 3f;
    // Start is called before the first frame update

    public void SetTarget(GameObject _target)
    {
        target = _target.transform;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movePos = Vector3.zero;

        transform.localRotation = Quaternion.Euler(CamRotation);

        Vector3 targetPos = Camera.main.WorldToScreenPoint(target.position);
        targetPos.z = 0f;
        Vector3 MousePos = Input.mousePosition;
        Vector3 Dir = MousePos - targetPos;
        Dir.Normalize();
        float Distance = Vector3.Distance(targetPos, MousePos);
        Distance = Mathf.Min(MaxRangeDistance, Distance);

        if (TargetDistance > Distance)
        {
            movePos = target.position + CamPoision;
        }
        else
        {
            movePos = target.position + CamPoision + new Vector3(Dir.x, 0f, Dir.y) * (Distance / MaxRangeDistance * Range);
        }

        if (Vector3.Distance(transform.position, movePos) < Speed * Time.deltaTime)
        {
            transform.position = movePos;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, movePos, Speed * Time.deltaTime);
        }
    }
}
