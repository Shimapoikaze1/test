using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    public Vector2 initialVelocity;
    public GameObject fireball;
    public float spawnDistance = 1f; // 物体B在物体A前方多远生成
    public float projectileSpeed = 5f; // 物体B的初始速度
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
        // 获取输入方向
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // 如果有输入，则更新最后移动的方向
        if (new Vector2(moveX, 0) != Vector2.zero)
        {
            lastMoveDirection = new Vector2(moveX, 0).normalized;
        }
    }
    void ShootProjectile()
    {
        if (fireball != null)
        {
            // 计算生成位置（物体A的位置 + 方向 * 偏移距离）
            Vector2 update = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);//*1.25f);
            Vector2 spawnPos = /*(Vector2)transform.position*/ update  + lastMoveDirection * spawnDistance*0.8f;

            // 实例化物体B
            GameObject newProjectile = Instantiate(fireball, spawnPos, Quaternion.identity);

            // 设置物体B的初始速度
            Rigidbody2D projectileRb = newProjectile.GetComponent<Rigidbody2D>();
            FireBallAmount++;
            if (projectileRb != null)
            {
                // 给物体B一个瞬时的力，使其具有初速度:cite[3]
                projectileRb.AddForce(lastMoveDirection * projectileSpeed*1.5f, ForceMode2D.Impulse);
            }
            else
            {
                Debug.LogWarning("物体B的预制体上未找到Rigidbody2D组件！");
            }
        }
        else
        {
            Debug.LogWarning("projectilePrefab 未赋值！请将物体B的预制体拖拽到脚本上。");
        }
    }
}
