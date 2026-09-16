using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _status;

    [SerializeField]
    private string clientId, gameSlug;

    private static Up2UnityManager _up2jam;

    private async void Awake()
    {
        _status.text = "Waiting for connection...";
        if (_up2jam == null)
        {
            _up2jam = new(clientId, gameSlug);
            var res = await _up2jam.Connect();

            _status.text = $"Waiting for validation, user code: {res.UserCode}";
            Application.OpenURL(res.VerificationUri);

            while (true)
            {
                await Awaitable.WaitForSecondsAsync(.5f);
                if (await _up2jam.ValidateToken())
                {
                    _status.text = "Connected!";
                    return;
                }
            }
        }
    }
}
