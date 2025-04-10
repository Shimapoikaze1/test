using System.Collections;
using UnityEngine;

public class FlagPole : MonoBehaviour
{
    public Transform flag;
    public Transform poleBottom;
    public Transform castle;
    public float speed = 6f;
    public int nextWorld = 1;
    public int nextStage = 1;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out Player player))
        {
            StartCoroutine(MoveTo(flag, poleBottom.position));
            StartCoroutine(LevelCompleteSequence(player));
        }
    }
    
    private IEnumerator LevelCompleteSequence(Player player)
    {
        player.movement.enabled = false;

        yield return MoveTo(player.transform, poleBottom.position);
        yield return MoveTo(player.transform, player.transform.position + Vector3.right);
        yield return MoveTo(player.transform, player.transform.position + Vector3.right + Vector3.down);
        yield return MoveTo(player.transform, castle.position);

        player.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);

        GameManager.Instance.LoadLevel(nextWorld, nextStage);
    }
    private void SlideAnimate() 
    {
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        if (GameObject.Find("Small").GetComponent<SpriteRenderer>().enabled) 
        {
            Debug.Log("Loaded");
            GameObject.Find("Small").GetComponent<SpriteRenderer>().sprite = sprite1;
        }else if (GameObject.Find("Big").GetComponent<SpriteRenderer>().enabled) 
        {
            GameObject.Find("Big").GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        else if (GameObject.Find("fire").GetComponent<SpriteRenderer>().enabled)
        {
            GameObject.Find("fire").GetComponent<SpriteRenderer>().sprite = sprite3;
        }
    }
    private IEnumerator MoveTo(Transform subject, Vector3 position)
    {
        SlideAnimate();
        while (Vector3.Distance(subject.position, position) > 0.125f)
        {
            
            subject.position = Vector3.MoveTowards(subject.position, position, speed * Time.deltaTime);
            yield return null;
        }
        
        subject.position = position;
        
    }
    

}
