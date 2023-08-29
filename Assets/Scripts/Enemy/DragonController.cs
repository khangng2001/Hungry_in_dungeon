using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    public class DragonController : MonoBehaviour
    {
       [SerializeField] private Animator anim;
       private Vector3 moveDir = Vector3.zero;

      [SerializeField] private float horizontal;
      [SerializeField] private float vertical;
     [SerializeField] private bool isIdle = false;
       private void Update()
       {
           horizontal = Input.GetAxisRaw("Horizontal");
           vertical = Input.GetAxisRaw("Vertical");
           moveDir.Set(horizontal,vertical, 0f);
           moveDir.Normalize();
           transform.Translate(moveDir * (1.5f * Time.deltaTime));
           Animate();
           Debug.Log(moveDir);
       }
       private void Animate()
       {
           isIdle = horizontal == 0 && vertical == 0;
           if (isIdle)
           {
               anim.SetBool("isMoving", false);
           }
           else
           {
               anim.SetFloat("verticalMovement", moveDir.y);
               anim.SetFloat("horizontalMovement", moveDir.x);
               anim.SetBool("isMoving", true);
           }
       }
    }
}
