using System.Collections;
using UnityEngine;
using DG.Tweening;

public class FancyDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject doorLeft;
    [SerializeField]
    private GameObject doorRight;

    private Transform _TDL;
    private Transform _TDR;

    private Vector3 _PDLO;
    private Vector3 _PDRO;

    private Vector3 _PDLD;
    private Vector3 _PDRD;

    [SerializeField]
    Ease easeType;
    [SerializeField]
    float duration = 1.5f;

    [SerializeField]
    float openDistance = 1f;

    private Collider2D _Collider;
    private AudioSource _AS;


    private void Awake()
    {
        _AS = GetComponent<AudioSource>();
        _Collider = GetComponent<Collider2D>();

        _TDL = doorLeft.GetComponent<Transform>();
        _TDR = doorRight.GetComponent<Transform>();

        _PDLO = _TDL.position;
        _PDRO = _TDR.position;

        _PDLD = _PDLO - new Vector3(openDistance, 0, 0);
        _PDRD = _PDRO + new Vector3(openDistance, 0, 0);
    }

    public void Open()
    {
        _AS.Play();
        StartCoroutine(EOpen());
        _TDL.DOMove(_PDLD, duration).SetEase(easeType);
        _TDR.DOMove(_PDRD, duration).SetEase(easeType);
    }

    public void Close()
    {
        _AS.Play();

        StartCoroutine(EClose());
        _TDL.DOMove(_PDLO, duration).SetEase(easeType);
        _TDR.DOMove(_PDRO, duration).SetEase(easeType);
    }

    private IEnumerator EOpen()
    {
        yield return new WaitForSeconds(0.6f);
        _Collider.enabled = false;
    }

    private IEnumerator EClose()
    {
        yield return new WaitForSeconds(0.3f);
        _Collider.enabled = true;
    }
}