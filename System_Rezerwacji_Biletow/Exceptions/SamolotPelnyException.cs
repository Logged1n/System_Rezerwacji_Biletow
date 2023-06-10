using System.Runtime.Intrinsics.Arm;

namespace System_Rezerwacji_Biletow.Exceptions;

public class SamolotPelnyException : Exception
{
    public SamolotPelnyException() : base("Samolot jest juz pelny!")
    {
    }
}