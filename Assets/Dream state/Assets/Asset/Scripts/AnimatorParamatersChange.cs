using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FiveRabbitsDemo
{
    public class AnimatorParamatersChange : MonoBehaviour
    {
        [SerializeField]
        [Range(1, 20)]
        private float speed = 18;
        private Vector2 rotation = Vector2.zero;
        public float mouse = 10;
        private string[] states = new string[] { "Idle", "Run" };
        public DreamDoor doorOpen;
        private Animator RabAnim;
        public Text HappyText;
        private int points = 0;
     
     

        // Use this for initialization
        void Start()
        {
            ParticleSystem Burst = GetComponent<ParticleSystem>();
            RabAnim = GetComponent<Animator>();
            RabAnim.Play("Idle");
        }

        // Update is called once per frame
        void Update()
        {

            //movement- Use arrow keys
            Vector3 direction = Vector3.zero;


            if (Input.GetKey(KeyCode.W))
            {
                direction.z = 1;
                RabAnim.Play("Run");
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction.z = -1;
                RabAnim.Play("Run");
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction.x = 1;
                RabAnim.Play("Run");
            }
            if (Input.GetKey(KeyCode.A))
            {
                direction.x = -1;
                RabAnim.Play("Run");
            }

            if (Input.anyKey ==false){
                RabAnim.Play("Idle");
            }

            transform.Translate(speed * direction.normalized * Time.deltaTime);


            MouseMove();

        }


        //Happiness sphere collider
        void OnTriggerEnter(Collider other)
        {
            if (other != null)
            {
                //BurstMode();
                points++;
                HappyText.text = ("You have released the lever-the door is open. Find the cheese.");
                Particles p = other.GetComponent<Particles>();
                if (p != null)
                {
                    p.CheeseExplode();
                }

                Destroy(other.gameObject);

                doorOpen.PointCollect();

                if(points ==2){
                    SceneManager.LoadScene(0);
                }
            }

        }

            
            //Mouse rotation/follow
            private void MouseMove()
              {
                rotation.x += -Input.GetAxis("Mouse Y");
                rotation.y += Input.GetAxis("Mouse X");
                rotation.x = Mathf.Clamp(rotation.x, -10f, 10f);

                transform.eulerAngles = (mouse * new Vector2(0, rotation.y));
                Camera.main.transform.localRotation = Quaternion.Euler(mouse * rotation.x, 0, 0);
             }


    }

}
