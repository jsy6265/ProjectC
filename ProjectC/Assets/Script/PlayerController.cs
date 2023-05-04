using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectC
{
    public class PlayerController : MonoBehaviour
    {

        private Animator animator;
        private Camera camera;

        private Vector3 destination;
        private bool isMove;
        public float moveSpeed;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            camera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(1))
            {
                RaycastHit hit;
                if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    SetDestination(hit.point);
                }
            }

            PlayerMove();

        }

        private void PlayerMove()
        {
            if(isMove == true)
            {
                if(Vector3.Distance(destination, transform.position) <= 0.1f)
                {
                    isMove = false;
                    animator.SetBool("isRun", false);
                    return;
                }

                var dir = destination - transform.position;
                transform.position += dir.normalized * Time.deltaTime * moveSpeed;

                transform.LookAt(new Vector3(destination.x, destination.y, destination.z));

                animator.SetBool("isRun", true);
            }
        }

        private void SetDestination(Vector3 dest)
        {
            destination = dest;
            isMove = true;
        }


    }
}

