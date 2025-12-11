using System.Windows.Input;

public static class ManagerSettings
{
    public static Key KeyHaut = Key.Z;
    public static Key KeyBas = Key.S;
    public static Key KeyGauche = Key.Q;
    public static Key KeyDroite = Key.D;
    public static Key KeySprint = Key.LeftShift;
    public static Key KeyAction = Key.E;


    public static double VolumeGeneral = 1.0;   // 0.0 → 1.0
    public static double VolumeMusique = 1.0;
    public static double VolumeEffets = 1.0;
    
    public static bool KeyAlreadyUsed(Key key)
    {
        return KeyHaut == key ||
               KeyBas == key ||
               KeyGauche == key ||
               KeyDroite == key ||
               KeySprint == key ||
               KeyAction == key;
    }


}

