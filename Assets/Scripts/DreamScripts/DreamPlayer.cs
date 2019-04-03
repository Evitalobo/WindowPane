using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

    public class DreamPlayer : MonoBehaviour
    {
        [SerializeField]
        [Range(1, 20)]
        private float speed = 18;
        private Vector2 rotation = Vector2.zero;
        public float mouse = 10;
        private string[] states = new string[] { "Idle", "Run" };
        public Lever doorOpen;
        private Animator playerAnim;
        public Text HappyText;
        private int points = 0;
   
     

        // Use this for initialization
        void Start()
        {
            ParticleSystem Burst = GetComponent<ParticleSystem>();
            playerAnim = GetComponent<Animator>();
          //  playerAnim.Play("Idle");
            
        }

        // Update is called once per frame
        void Update()
        {

            //movement- Use arrow keys
            Vector3 direction = Vector3.zero;


            if (Input.GetKey(KeyCode.A))
            {
                direction.z = 1;
            //    playerAnim.Play("Run");
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction.z = -1;
           //     playerAnim.Play("Run");
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction.x = -1;
            //    playerAnim.Play("Run");
            }
            if (Input.GetKey(KeyCode.W))
            {
                direction.x = 1;
            //    playerAnim.Play("Run");
            }

            if (Input.anyKey ==false){
           //     playerAnim.Play("Idle");
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
                HappyText.text = ("The power is off and the door is open. I need to see if there's any way to escape.");
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
                Camera.main.transform.localRotation = Quaternion.Euler(mouse * rotation.x, 90, 0);
             }


    }

