using UnityEngine;

namespace memory.testing
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : AutoSingletonManager<AudioManager>
    {
        #region Serial Field
        [SerializeField] private AudioClip matchSound, matchFailSound;
        #endregion

        #region Private Variable
        private AudioSource _audioSource;
        #endregion

        #region Unity Callbacks
        private void Start() => _audioSource = GetComponent<AudioSource>();
        #endregion

        #region Internal Methods
        internal void PlayOneShootFlipMatchSound(bool isMatch)
        {
            _audioSource.clip = isMatch ? matchSound : matchFailSound;
            _audioSource.Play();
        }
        #endregion
    }
}
