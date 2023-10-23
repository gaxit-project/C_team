//stage1�V�[����Goal�ɃA�^�b�`

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceController : MonoBehaviour
{

    [SerializeField] private GameObject target; //target��GoalObject
    [SerializeField] private GameObject player; //player��Girl
    [SerializeField] Text counter; //counter��Distance
    [SerializeField] Slider dsSlider; //dsSlider��GoalDistance

    void Start()
    {
        /* �^�[�Q�b�g�̃|�W�V�������擾 */
        Vector3 targetPos = target.transform.position;
        /* �v���C���[�̃|�W�V�������擾 */
        Vector3 playerPos = player.transform.position;
        /* �^�[�Q�b�g�ƃv���C���[�̋������擾 */
        int dis = (int)Vector3.Distance(targetPos, playerPos);

        //�X���C�_�[�̍Œ�l�ƍő�l�̐ݒ�
        dsSlider.minValue = 0;
        dsSlider.maxValue = dis;

        //�X���C�_�[�̌��ݒl�̐ݒ�
        dsSlider.value = dis;
    }

    void Update()
    {
        /* �^�[�Q�b�g�̃|�W�V�������擾 */
        Vector3 targetPos = target.transform.position;

        /* �v���C���[�̃|�W�V�������擾 */
        Vector3 playerPos = player.transform.position;

        /* �^�[�Q�b�g�ƃv���C���[�̋������擾 */
        int dis = (int)Vector3.Distance(targetPos, playerPos);

        //�X���C�_�[�̌��ݒl�̐ݒ�
        dsSlider.value = dis;

        //�S�[���܂ł̋�����\��
        counter.text = "����" + Convert.ToString(dis) + "m";
    }
}
