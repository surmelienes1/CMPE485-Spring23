using UnityEngine;

public class ZombieFollowerControl : MonoBehaviour
{
    private enum ControlMode
    {
        /// <summary>
        /// Up moves the character forward, left and right turn the character gradually and down moves the character backwards
        /// </summary>
        Tank,
        /// <summary>
        /// Character freely moves in the chosen direction from the perspective of the camera
        /// </summary>
        Direct
    }

    [SerializeField] private float m_moveSpeed = 2;
    [SerializeField] private float m_turnSpeed = 200;

    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;

    [SerializeField] private ControlMode m_controlMode = ControlMode.Tank;

    private float m_currentV = 0;
    private float m_currentH = 0;

    public Transform target;

    private readonly float m_interpolation = 10;
    
    private Vector3 m_currentDirection = Vector3.zero;

    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
    }

    private void Update(){
        if (target == null)
        {
            m_animator.SetFloat("MoveSpeed", 0);
            return;
        }
        float dist = Vector3.Distance(target.position, transform.position);
        if(dist < 50)
        {
            m_animator.SetFloat("MoveSpeed", GetComponent<Rigidbody>().velocity.magnitude);
        }
        else
        {
            m_animator.SetFloat("MoveSpeed", 0);
        }
    }

}


