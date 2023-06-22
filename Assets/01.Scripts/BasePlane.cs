using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BasePlane : MonoBehaviour
{
    private Coroutine pendulumCor = null;
    private Sequence triggerSqc = null;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("other = " + collision.gameObject.name);
        this.transform.DOLocalMoveY(-0.025f, 0.1f);
        StartPendulum();
    }




    private void StartPendulum()
    {
        if(pendulumCor != null)
        {
            StopCoroutine(pendulumCor);
            pendulumCor = null;
        }

        pendulumCor = StartCoroutine(PendulumCor());
    }

    IEnumerator PendulumCor()
    {
        yield return new WaitForSeconds(0.25f);
        triggerSqc = DOTween.Sequence();
        triggerSqc.Append(this.transform.DOLocalMoveY(0.0f, 0.075f).SetLoops(-1, LoopType.Yoyo));

        yield return new WaitForSeconds(0.5f);

        if (triggerSqc.IsActive())
            triggerSqc.Kill();

        triggerSqc = null;

        this.gameObject.SetActive(false);

    }

}
