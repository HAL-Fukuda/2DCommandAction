using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitcher : MonoBehaviour
{
    public Sprite[] Images;
    private int currentIdx = -1;
    private Sprite originalImage;

    // Start is called before the first frame update
    void Start()
    {
        // ���݃Z�b�g����Ă���摜�擾
        originalImage = GetComponent<SpriteRenderer>().sprite;
    }

   /* private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SwitchSprite();
            //SwitchSprite(0);
        }
    }*/

    // �X�v���C�g�̐؂�ւ�
    public void SwitchSprite(int idx) // �����Ŕԍ����w��
    {
        currentIdx = idx;

        // �摜��NULL�Ȃ�G���[
        if (Images[currentIdx] == null)
        {
            Debug.Log("�摜�Q�ƃG���[�B");
            return;
        }

        // �摜��ύX
        GetComponent<SpriteRenderer>().sprite = Images[currentIdx];
    }

    public void SwitchSprite() // �A�ԂŐ؂�ւ���
    {
        currentIdx++;
        if(currentIdx >= Images.Length) // �T�C�Y�𒴂�����0�ɖ߂�
        {
            currentIdx = 0;
        }

        // �摜��NULL�Ȃ�G���[
        if (Images[currentIdx] == null)
        {
            Debug.Log("�摜�Q�ƃG���[�B");
            return;
        }

        // �摜��ύX
        GetComponent<SpriteRenderer>().sprite = Images[currentIdx];
    }

    public void DebugMode()
    {
        Debug.Log("SpriteSwitcher���Ă΂ꂽ");
    }
}
