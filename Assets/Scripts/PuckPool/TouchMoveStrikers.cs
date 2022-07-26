using UnityEngine;

public class TouchMoveStrikers : MonoBehaviour
{
    Transform _strikerTransform;
    Vector2 _offset;
    bool _canDrag = false;

    void Update()
    {
        Vector2 _position;
        Touch[] _touchCount = Input.touches;
        foreach (var _touch in _touchCount)
        {
        Vector2 _touchPosition = _touch.position;

        if (_touch.phase == TouchPhase.Began)
        {
        Ray _ray = Camera.main.ScreenPointToRay(_touchPosition);
        RaycastHit2D _raycastHit = Physics2D.Raycast(_ray.origin, -Vector2.up);
            if (_raycastHit.collider.tag == "Strikers")
            {
                _strikerTransform = _raycastHit.transform;
                _position = new Vector2(_touchPosition.x, _touchPosition.y);
                _position = Camera.main.ScreenToWorldPoint(_position);
                _offset.x = _strikerTransform.position.x - _position.x;
                _offset.y = _strikerTransform.position.y - _position.y;
                _canDrag = true;
            }
            if (_raycastHit.collider.tag == "OppoStrikers")
            {
                _strikerTransform = _raycastHit.transform;
                _position = new Vector2(_touchPosition.x, _touchPosition.y);
                _position = Camera.main.ScreenToWorldPoint(_position);
                _offset.x = _strikerTransform.position.x - _position.x;
                _offset.y = _strikerTransform.position.y - _position.y;
                _canDrag = true;
            }                
        }

        if (_canDrag && _touch.phase == TouchPhase.Moved)
        {
            _position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            _position = Camera.main.ScreenToWorldPoint(_position);
            _strikerTransform.position = _position + _offset;
        }
        if (_canDrag && (_touch.phase == TouchPhase.Ended || _touch.phase == TouchPhase.Canceled))
            _canDrag = false;
        }
    }
}
