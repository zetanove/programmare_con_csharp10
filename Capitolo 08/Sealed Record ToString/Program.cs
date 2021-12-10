// See https://aka.ms/new-console-template for more information
Point pt=new Point(1,2);
Console.WriteLine("Point: "+pt);

Point pt3=new Point3D(1,2,3);
Console.WriteLine("Point3D: "+pt3);

public record Point(int X,int Y){
    public sealed override string ToString()
    {
        return "io sono un punto";
    }
}

public record Point3D(int X,int Y, int Z): Point(X,Y){
    public override string ToString()
    {
        return "io sono un punto 3d";
    }
}


