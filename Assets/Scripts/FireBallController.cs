using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    public Vector2 initialVelocity;
    public GameObject fireball;
    public float spawnDistance = 1f; // ����B������Aǰ����Զ����
    public float projectileSpeed = 5f; // ����B�ĳ�ʼ�ٶ�
    private Vector2 lastMoveDirection = Vector2.right;
    
    private Rigidbody2D rb;
    public int MAxExistfireballAmount = 1;
    public int FireBallAmount = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    public void shootbuttom()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleInput();
        if (Input.GetKeyDown(KeyCode.Space) && FireBallAmount < MAxExistfireballAmount) 
        {
            ShootProjectile();
           
        }
        
    }
    void HandleInput()
    {
        // ��ȡ���뷽��
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // ��������룬���������ƶ��ķ���
        if (new Vector2(moveX, 0) != Vector2.zero)
        {
            lastMoveDirection = new Vector2(moveX, 0).normalized;
        }
    }
    void ShootProjectile()
    {
        if (fireball != null)
        {
            // ��������λ�ã�����A��λ�� + ���� * ƫ�ƾ��룩
            Vector2 update = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);//*1.25f);
            Vector2 spawnPos = /*(Vector2)transform.position*/ update  + lastMoveDirection * spawnDistance*0.8f;

            // ʵ��������B
            GameObject newProjectile = Instantiate(fireball, spawnPos, Quaternion.identity);

            // ��������B�ĳ�ʼ�ٶ�
            Rigidbody2D projectileRb = newProjectile.GetComponent<Rigidbody2D>();
            FireBallAmount++;
            if (projectileRb != null)
            {
                // ������Bһ��˲ʱ������ʹ����г��ٶ�:cite[3]
                projectileRb.AddForce(lastMoveDirection * projectileSpeed*1.5f, ForceMode2D.Impulse);
            }
            else
            {
                Debug.LogWarning("����B��Ԥ������δ�ҵ�Rigidbody2D�����");
            }
        }
        else
        {
            Debug.LogWarning("projectilePrefab δ��ֵ���뽫����B��Ԥ������ק���ű��ϡ�");
        }
    }
}
