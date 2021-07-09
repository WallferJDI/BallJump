using UnityEngine;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    private Vector3 _minPosition;

    private Ball _ball;
    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _minPosition = _ball.transform.position;
    }

    private void Update()
    {
       
       if(_ball.transform.position.y < _minPosition.y)
        {
            TrackBall();
            _minPosition = _ball.transform.position;

        }
    }

    private void TrackBall()
    {
        transform.position = _ball.transform.position + _offset;
        transform.LookAt(_ball.transform);
    }
}
