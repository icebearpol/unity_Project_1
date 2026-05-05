
using System.Collections;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public GameObject monsterModel;
    public float attackDistance = 3f;
    public float stopDistance = 0.4f; 
    public float jumpscareDuration = 0.4f;
    public float shakeIntensity = 0.5f;

    private bool isAttacking = false;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (monsterModel != null) monsterModel.SetActive(false);

        // so that the image is transparent at the start
        if (flashImage != null)
        {
            flashImage.color = new Color(0, 0, 0, 0f); 
        }
    }

    public void TriggerAttack()
    {
        if (isAttacking) return;
        isAttacking = true;

        Camera cam = Camera.main;
        if (cam == null || monsterModel == null) return;

        monsterModel.SetActive(true);
        if (audioSource != null) audioSource.Play();

        // Spawn at floor level relative to camera
        Vector3 spawnPos = cam.transform.position + cam.transform.forward * attackDistance;
        spawnPos.y = cam.transform.position.y - 1.1f; 

        monsterModel.transform.position = spawnPos;
        StartCoroutine(Jumpscare(cam));
    }
    public UnityEngine.UI.Image flashImage;
    IEnumerator Jumpscare(Camera cam)
    {
        float timer = 0f;
        Vector3 startPos = monsterModel.transform.position;
        Transform camTransform = cam.transform;

        while (timer < jumpscareDuration)
        {
            timer += Time.deltaTime;
            float progress = timer / jumpscareDuration;

         
            if (flashImage != null)
            {
                flashImage.color = new Color(0, 0, 0, Random.Range(0f, 0.6f));
            }

            Vector3 targetPoint = camTransform.position + (camTransform.forward * 0.8f);
            targetPoint.y = startPos.y;
            monsterModel.transform.position = Vector3.Lerp(startPos, targetPoint, progress);

            
            Vector3 directionToCamera = camTransform.position - monsterModel.transform.position;
            directionToCamera.y = 0; 

            if (directionToCamera != Vector3.zero)
            {
                
                monsterModel.transform.rotation = Quaternion.LookRotation(directionToCamera);
            }

            yield return null;
        }

      //when monster attacks
        if (flashImage != null) flashImage.color = Color.black;
        Time.timeScale = 0f;
    }
}