using System;
using System.IO;
using System.Windows.Media;

public static class Audio
{
    // === MUSIQUE ===
    private static readonly MediaPlayer musicPlayer = new MediaPlayer();
    private static bool isLooping = false;

    // === EFFETS ===
    private static readonly MediaPlayer sfxPlayer = new MediaPlayer();

    // ---- CONSTRUCTEUR STATIC ----
    static Audio()
    {
        // MUSIQUE
        musicPlayer.MediaOpened += (s, e) =>
        {
            musicPlayer.Volume = ManagerSettings.VolumeMusique * ManagerSettings.VolumeGeneral;
            musicPlayer.Position = TimeSpan.Zero;
            musicPlayer.Play();
        };

        musicPlayer.MediaEnded += (s, e) =>
        {
            if (!isLooping) return;

            musicPlayer.Position = TimeSpan.Zero;
            musicPlayer.Play();
        };

        // SFX
        sfxPlayer.MediaOpened += (s, e) =>
        {
            sfxPlayer.Volume = ManagerSettings.VolumeEffets * ManagerSettings.VolumeGeneral;
            sfxPlayer.Position = TimeSpan.Zero;
            sfxPlayer.Play();
        };
    }

    // ---- LECTURE MUSIQUE ----
    public static void PlayMusic(string relativePath, bool loop = true)
    {
        isLooping = loop;

        var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

        if (!File.Exists(fullPath))
        {
            Console.WriteLine("[Audio] MUSIQUE INTROUVABLE > " + fullPath);
            return;
        }

        musicPlayer.Stop();
        musicPlayer.Open(new Uri(fullPath, UriKind.Absolute));
    }

    public static void StopMusic()
    {
        isLooping = false;
        musicPlayer.Stop();
    }

    public static void RefreshMusicVolume()
    {
        musicPlayer.Volume = ManagerSettings.VolumeMusique * ManagerSettings.VolumeGeneral;
    }

    // ---- LECTURE SFX ----
    public static void PlaySFX(string relativePath)
    {
        var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

        if (!File.Exists(fullPath))
        {
            Console.WriteLine("[Audio] SFX INTROUVABLE > " + fullPath);
            return;
        }

        sfxPlayer.Open(new Uri(fullPath, UriKind.Absolute));
    }
    public static void RefreshVolumes()
    {
        musicPlayer.Volume = ManagerSettings.VolumeMusique * ManagerSettings.VolumeGeneral;
        sfxPlayer.Volume = ManagerSettings.VolumeEffets * ManagerSettings.VolumeGeneral;
    }
}
