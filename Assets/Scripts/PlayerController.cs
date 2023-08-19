using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private int maxHealth = 0;
    private int currentHealth = 0;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private TextMeshProUGUI textHealthBar;

    private int maxStamina = 0;
    private int currentStamina = 0;
    [SerializeField] private GameObject staminaBar;
    [SerializeField] private TextMeshProUGUI textStaminaBar;

    private float countTime = 0f;

    private Animator ani;

    private PlayerInput input;

    [SerializeField]private float moveSpeed = 5f;
    private Vector3 moveDir = Vector3.zero;

    private void Awake()
    {
        ani = GetComponentInChildren<Animator>();
        input = GetComponent<PlayerInput>();

        SetHealth(100);
        SetStamina(20);
    }

    void Start()
    {
        
    }

    void Update()
    {
        Moving();

        FlipXByMouse();

        FlipYByMouse();

        IncreaseStaminaByTime();
    }

    void FlipXByMouse()
    {
        Vector2 direction = input.inputMosue - new Vector2(transform.position.x, transform.position.y);

        if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (direction.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void FlipYByMouse()
    {
        Vector2 direction = input.inputMosue - new Vector2(transform.position.x, transform.position.y);

        if (direction.y < 0)
        {
            ani.Play("DownRight");
        }
        else if (direction.y > 0)
        {
            ani.Play("UpRight");
        }
    }

    private void Moving()
    {
        float horizontal = input.horizontal;
        float vertical = input.vertical;

        moveDir.Set(horizontal, vertical, 0f);
        moveDir.Normalize();

        transform.Translate( moveDir * (moveSpeed * Time.deltaTime));
    }

    public void SetHealth(int newHealth)
    {
        maxHealth = newHealth;
        currentHealth = maxHealth;
        healthBar.GetComponent<Slider>().maxValue = maxHealth;
        LoadHealth();
    }

    public void LoadHealth()
    {
        textHealthBar.text = currentHealth + "/" + maxHealth;
        healthBar.GetComponent<Slider>().value = currentHealth;
    }

    public void IncreaseHealth(int newHealth)
    {
        if (currentHealth <= maxHealth)
        {
            currentHealth += newHealth;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

        LoadHealth();
    }

    public void DecreaseHealth(int lostHealth)
    {
        if (currentHealth > 0)
        {
            currentHealth -= lostHealth;

            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
        }

        LoadHealth();
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void SetStamina(int newStamina)
    {
        maxStamina = newStamina;
        currentStamina = maxStamina;
        staminaBar.GetComponent<Slider>().maxValue = maxStamina;
        LoadStamina();
    }

    public void LoadStamina()
    {
        textStaminaBar.text = currentStamina + "/" + maxStamina;
        staminaBar.GetComponent<Slider>().value = currentStamina;
    }

    public void IncreaseStamina(int newStamina)
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += newStamina;

            if (currentStamina > maxStamina)
            {
                currentStamina = maxStamina;
            }
        }

        LoadStamina();
    }

    public void DecreaseStamina(int lostStamina)
    {
        if (currentStamina >= 0)
        {
            currentStamina -= lostStamina;

            if (currentStamina < 0)
            {
                currentStamina = 0;
            }
        }

        LoadStamina();
    }

    public int GetStamina()
    {
        return currentStamina;
    }

    private void IncreaseStaminaByTime()
    {
        if (currentStamina < maxStamina)
        {
            countTime += Time.deltaTime;

            if (countTime > 1f)
            {
                IncreaseStamina(1);

                countTime = 0;
            }
        }
    }
}
