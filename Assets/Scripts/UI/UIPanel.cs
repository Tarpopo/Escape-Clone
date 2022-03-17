using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UIPanel : MonoBehaviour
{
    [SerializeField] private float _frames;
    [SerializeField] private float _showDelay;

    public void HideWindow()
    {
        StartCoroutine(DoScale(Vector3.zero, () => gameObject.SetActive(false)));
    }

    public void ShowWindow()
    {
        gameObject.SetActive(true);
        StartCoroutine(DoScale(Vector3.one, null));
    }

    public void ShowWithDelay() => Invoke(nameof(ShowWindow), _showDelay);

    private IEnumerator DoScale(Vector3 endScale, Action onAnimationEnd)
    {
        yield return new WaitForSeconds(_showDelay);
        var delta = (endScale - transform.localScale) / _frames;
        for (int i = 0; i < _frames; i++)
        {
            transform.localScale += delta;
            yield return new FixedUpdate();
        }

        onAnimationEnd?.Invoke();
    }
}