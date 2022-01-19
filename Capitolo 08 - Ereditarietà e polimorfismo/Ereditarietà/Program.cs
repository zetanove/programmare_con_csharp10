/*
 * Programmare con C# 8 guida completa
 * Autore: Antonio Pelleriti
 * Capitolo 8: ereditarietà
 */

using System.Collections;

namespace Capitolo8
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle v = new Vehicle();
            v.ModelName = "My Vehicle";
            v.MaxSpeed = 180;
            v.Accelerate();
            v.PrintInfo();
            v.Brake();
            v.PrintInfo();

            StreetVehicle sv1= new StreetVehicle(2);
            sv1.PrintInfo();
            //sv1.currentSpeed = 0;//Errore, campo non accessibile

            Car car = new Car();
            car.Accendi();
            car.Accelerate();
            car.PrintInfo();
            
            
            Vehicle sv2 = new StreetVehicle(4);

            //name hiding
            Airplane airplane = new Airplane();
            airplane.TakeOff();

            FlyingVehicle vair = airplane;
            vair.TakeOff();

            //virtual override
            Car ferrari = new Car();
            ferrari.Accelerate();

            Vehicle vf = ferrari;
            vf.Accelerate();

            //abstract class
            FlyingVehicle fv = new Helicopter();

            //interface ICruiseControl
            Supercar scar = new Supercar();
            scar.SetCruise(90);
            scar.StartControl();

            ICruiseControl sedan = new Sedan();
            (sedan as ICruiseControl).SetCruise(90);

            MyClass mc = new MyClass();
            //mc.Bar(); errore, interfaccia esplicita
            (mc as IFoo).Bar();

            //reimplementation
            Report report = new Report();
            report.Print();

            SubReport subReport = new SubReport();
            subReport.Print();

            IDocument irep = report;
            irep.Print();
            IDocument isub = subReport;
            isub.Print();

            irep.Print2();
            isub.Print2();

            irep.ExPrint();
            isub.ExPrint();

            irep.ExPrint2();
            SpecialSubReport ssub = new SpecialSubReport();
            IDocument issub = ssub;
            issub.ExPrint2();

            //IComparable objects sorting
            ArrayList list = new ArrayList();
            list.Add(new ComparableCar() { Targa = "DE234QW" });
            list.Add(new ComparableCar() { Targa = "CP787MC" });
            list.Add(new ComparableCar() { Targa = "BM41329" });
            list.Sort();

            //Abstract classes and interface
            MyDoc doc = new MyDoc();
            doc.Print();
            doc.Save();
        }
    }
}
