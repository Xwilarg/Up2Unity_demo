using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private string clientId, gameSlug;

    private static Up2JamManager _up2jam;

    private void Awake()
    {
        if (_up2jam == null)
        {
            _up2jam = new(clientId, gameSlug);
            StartCoroutine(_up2jam.ConnectCoroutine((info) =>
            {
            }));
        }
    }
}
