using TMPro;
using UnityEngine;

namespace ElasticRush.Core
{
    public class Ball : Enemy
    {
        //[SerializeField, Min(1)] private int _startLevel = 1;
        //[SerializeField] private TMP_Text _levelFrame;
        //[SerializeField] private Player _player;

        //private readonly ElasticBall _elsaticBall = new();

        //public int Level => _elsaticBall.Level;



        //private void Awake()
        //{
        //    _elsaticBall.SetLevel(_startLevel);

        //    ChangeSize(_elsaticBall.Size);
        //}

        //private void OnEnable()
        //{
        //    _player.LevelChanged += OnPlayerLevelChanged;
        //}

        //private void Start()
        //{
        //    _levelFrame.text = $"Lvl {Level}";
        //}

        //private void OnDisable()
        //{
        //    _player.LevelChanged -= OnPlayerLevelChanged;
        //}

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.TryGetComponent(out Player player))
        //    {
        //        if (player.Level >= Level)
        //        {
        //            player.LevelUp(Level);
        //            Destroy(gameObject);
        //        }
        //        else
        //        {
        //            player.Die();
        //        }
        //    }
        //}

        //private void ChangeSize(float size)
        //{
        //    transform.localScale = Vector3.one * size;

        //    transform.localPosition = new Vector3(
        //                transform.position.x,
        //                transform.localScale.y / 2,
        //                transform.localPosition.z);
        //}

        //private void OnPlayerLevelChanged()
        //{
        //    if (_player.Level >= Level)
        //        _levelFrame.color = Color.green;
        //    else
        //        _levelFrame.color = Color.red;
        //}
    }
}