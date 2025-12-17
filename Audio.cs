using System;
using System.IO;
using System.Windows.Media;

public static class Audio
{
    // === MUSIQUE ===
    private static readonly MediaPlayer _MusiqueJoueur = new MediaPlayer();
    private static bool _EstJouee = false;

    // === EFFETS ===
    private static readonly MediaPlayer sfxPlayer = new MediaPlayer();

    public static MediaPlayer MusiqueJoueur
    {
        get
        {
            return _MusiqueJoueur;
        }
    }

    public static bool EstJouee
    {
        get
        {
            return _EstJouee;
        }

        set
        {
            _EstJouee = value;
        }
    }

    // ---- CONSTRUCTEUR STATIC ----
    static Audio()
    {
        // MUSIQUE
        MusiqueJoueur.MediaOpened += (s, e) =>
        {
            MusiqueJoueur.Volume = ManagerSettings.VolumeMusique * ManagerSettings.VolumeGeneral;
            MusiqueJoueur.Position = TimeSpan.Zero;
            MusiqueJoueur.Play();
        };

        _MusiqueJoueur.MediaEnded += (s, e) =>
        {
            if (!_EstJouee) return;

            MusiqueJoueur.Position = TimeSpan.Zero;
            MusiqueJoueur.Play();
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
    public static void JouerMusique(string CheminRelatif, bool EstJouee = true)
    {
        _EstJouee = EstJouee;

        var CheminAbsolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CheminRelatif);

        if (!File.Exists(CheminAbsolu))
        {
            Console.WriteLine("[Audio] MUSIQUE INTROUVABLE > " + CheminAbsolu);
            return;
        }

        MusiqueJoueur.Stop();
        MusiqueJoueur.Open(new Uri(CheminAbsolu, UriKind.Absolute));
    }

    public static void ArretMusique()
    {
        EstJouee = false;
        MusiqueJoueur.Stop();
    }

    public static void MiseAjourVolumeMusique()
    {
        MusiqueJoueur.Volume = ManagerSettings.VolumeMusique * ManagerSettings.VolumeGeneral;
    }

    // ---- LECTURE SFX ----
    public static void PlaySFX(string CheminRelatif)
    {
        var CheminAbsolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CheminRelatif);

        if (!File.Exists(CheminAbsolu))
        {
            Console.WriteLine("[Audio] SFX INTROUVABLE > " + CheminAbsolu);
            return;
        }

        sfxPlayer.Open(new Uri(CheminAbsolu, UriKind.Absolute));
    }
    public static void MiseAjourVolume()
    {
        MusiqueJoueur.Volume = ManagerSettings.VolumeMusique * ManagerSettings.VolumeGeneral;
        sfxPlayer.Volume = ManagerSettings.VolumeEffets * ManagerSettings.VolumeGeneral;
    }
}
