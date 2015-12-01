using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Character_behaviour : MonoBehaviour
{
	#region [ Fields ]
	[Range(0.01f, 20.0f)]
	[SerializeField]
	private float m_Speed = 5.0f;
	private Rigidbody2D m_Rigidbody;
	private Transform m_Transform;
	private Vector3 m_Movement = Vector3.zero;

	private bool walking;
	private Animator playerAnimation;
	#endregion
	
	#region [ Start ]
	void Awake()
	{
		m_Rigidbody = GetComponent<Rigidbody2D>();
		m_Transform = GetComponent<Transform>();
	}
	
	void Start()
	{
		// m_Rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
		walking = false;
		playerAnimation = GetComponent<Animator>();
	}
	#endregion
	
	#region [ Update ]
	void FixedUpdate()
	{
		float vertical = Input.GetAxisRaw("Vertical");
		float horizontal = Input.GetAxisRaw("Horizontal");
		Move(vertical, horizontal);
		if((vertical !=0 || horizontal != 0) && Game_behaviour.begin != 1)
			Game_behaviour.begin = 1;
	}
	#endregion
	
	#region [ Move Player ]
	void Move(float vertical, float horizontal)
	{
		m_Movement.Set(horizontal, vertical, 0.0f);
		m_Movement = m_Movement.normalized * m_Speed * Time.deltaTime;
		m_Rigidbody.MovePosition (m_Transform.position + m_Movement);

		if(horizontal > 0 )
			playerAnimation.SetBool("Walk",true);
		else if(horizontal < 0)
		{
			playerAnimation.SetBool("Walk",true);
		}
		else if(vertical > 0)
		{
			playerAnimation.SetBool("Walk",true);
		}
		else if(vertical < 0)
		{
			playerAnimation.SetBool("Walk",true);
		}
		else
			playerAnimation.SetBool("Walk",false);
	}
	#endregion
}