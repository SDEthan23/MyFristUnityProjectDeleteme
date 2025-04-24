using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject health;

    // 오디오 관련 변수 추가
    [SerializeField] private AudioClip damageSound; // 인스펙터에서 대미지 사운드 할당
    [SerializeField] private AudioClip deathSound; // 사망 사운드 (선택사항)
    private AudioSource audioSource;

    // 사망 상태 추적을 위한 변수 추가
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        health.GetComponent<HealthGetter>().ChangeHealth(currentHealth.ToString());
        //healthGetter.ChangeHealth();

        // AudioSource 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();

        // AudioSource가 없다면 추가하기
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void TakeDamage(int damage)
    {
        // 이미 사망했다면 더 이상 대미지를 입지 않음
        if (isDead)
            return;

        currentHealth -= damage;
        health.GetComponent<HealthGetter>().ChangeHealth(currentHealth.ToString());

        // 대미지 사운드 재생
        if (damageSound != null && audioSource != null && currentHealth > 0)
        {
            // 약간의 피치 변화를 주어 다양성 추가 (선택사항)
            audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
            audioSource.PlayOneShot(damageSound);
        }

        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        // 사망 상태로 설정
        isDead = true;

        Debug.Log("Player Died :)");

        // 사망 사운드 재생 (딱 한 번만)
        if (deathSound != null && audioSource != null)
        {
            audioSource.pitch = 1.0f; // 기본 피치로 재설정
            audioSource.PlayOneShot(deathSound);

            // 필요하다면 사망 사운드가 끝날 때까지 캐릭터를 바로 파괴하지 않게 할 수 있습니다
            // StartCoroutine(DeathSequence());
        }

        // 여기에 추가적인 사망 로직 (애니메이션 재생, 게임 오버 화면 표시 등)
    }

    // 필요한 경우 사망 시퀀스 코루틴 (선택사항)
    /*
    private IEnumerator DeathSequence()
    {
        // 사망 사운드 길이만큼 대기 (+ 약간의 여유)
        yield return new WaitForSeconds(deathSound.length + 0.1f);
        
        // 사망 후 추가 처리
        // Destroy(gameObject); 또는 다른 사망 처리 로직
    }
    */
}