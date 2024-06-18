using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour
{
    [Header("Scene Management")]
    public string sceneToLoad;         // Nama scene yang akan dimuat
    public float loadingDelay = 2f;    // Waktu jeda sebelum scene dimuat (dalam detik)

    // Fungsi ini dipanggil saat tombol "Play" ditekan
    public void LoadScene()
    {
        // Sembunyikan elemen UI lainnya (misalnya, menu utama)
        // ... (Tambahkan kode untuk menyembunyikan UI lainnya di sini)

        // Mulai coroutine untuk jeda waktu dan loading scene
        StartCoroutine(LoadWithDelay(sceneToLoad));
    }

    // Coroutine untuk memberikan jeda waktu sebelum memuat scene
    IEnumerator LoadWithDelay(string sceneName)
    {
        yield return new WaitForSeconds(loadingDelay); // Tunggu selama loadingDelay detik
        SceneManager.LoadScene(sceneName); // Muat scene
    }
}
