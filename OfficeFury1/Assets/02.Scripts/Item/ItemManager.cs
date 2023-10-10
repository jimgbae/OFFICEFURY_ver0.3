using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<BaseItem> Item_Info; //����Ʈ�� �����۵� ����

    public void SetItem() //������ �����͸� ��������� ���
    {
        Item_Info = new List<BaseItem>();
        //Resources ���� �ȿ� �ִ� Item ���� ����
        //��� BaseItem ��ũ��Ʈ�� ������ �ִ� �����͸� ������
        BaseItem[] loadedItems = Resources.LoadAll<BaseItem>("ItemData");

        //List�� �߰�
        Item_Info.AddRange(loadedItems);
    }

    public void Start()
    {
        SetItem();
    }
}
