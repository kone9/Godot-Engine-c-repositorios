using Godot;
using System;

public class Escena3D : Spatial
{
    //el raycast en 2D parece que tiene que ser con colisiones de tipo box
    private Node col;//referencia a la colisión
    private RayCast rayo;//referencia al rayo
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        rayo = GetNode<RayCast>("rayo");//busco al nodo hijo
    }

    public override void _PhysicsProcess(float delta)
    {
        //GD.Print(rayo.IsColliding());//si el rayo colisiona o no
        col = (Node)rayo.GetCollider();//devuelve el objeto que colisiona o vacio
        //es importante verificar que col no sea null,sino tenemos ese error
        if(col != null && col.IsInGroup("StaticBodyAzul"))//si la colisión esta en el grupo
        {
            GD.Print("Colisiono con CUBO AZUL");
        }
        else if(col != null && col.IsInGroup("StaticBodyRED"))//si la colisión esta en el grupo
        {
            GD.Print("Colisiono con CUBO ROJO");
        }
        else
        {
             GD.Print("El raycast no colisiona con nada");
        }
    }

}
