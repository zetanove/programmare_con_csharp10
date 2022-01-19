/*
 * Programmare con C# 7 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 7: ereditarietà interfacce
 */

using System;


namespace Capitolo8
{

    public interface ICruiseControl
    {
        int? CruiseSpeed { get; }
        void ResetCruise();
        void SetCruise(int speed);
        void StartControl();
    }

    public struct Coordinate
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public interface IAutoPilot : ICruiseControl
    {
        Coordinate Destination { get; set; }
        void Activate();
        void Deactivate();
    }
}
