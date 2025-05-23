using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public int damage;
    public float damageRate;

    private List<IDamagable> things = new List<IDamagable>();

    private void Start()
    {
        // ����Ƽ ���Ĺ��� ���� �Ű����� ���� Ȯ���غ���
        // ��ũ(���� Ŭ��)
        InvokeRepeating("DealDamage", 0, damageRate);
    }

    void DealDamage()
    {
        // things ����Ʈ�� �߰� �� IDamagable ��ü�� ������ �Լ� ȣ��
        for (int i = 0; i < things.Count; i++)
        {
            things[i].TakePhysicalDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ��ü�� IDamagable�� ��ӵǾ� ������ List�� �߰�
        if (other.TryGetComponent(out IDamagable damagable))
        {
            things.Add(damagable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Exit �Ǵ� ��ü�� IDamagable�� ��ӵǾ� ������ List���� ����
        if (other.TryGetComponent(out IDamagable damagable))
        {
            things.Remove(damagable);
        }
    }
}