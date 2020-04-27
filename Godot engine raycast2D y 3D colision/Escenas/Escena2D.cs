using Godot;
using System;

public class Escena2D : Node2D
{
    
    private Node col;//referencia a la colisión
    private RayCast2D rayo;//referencia al rayo
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        rayo = GetNode<RayCast2D>("rayo");//busco al nodo hijo
    }

    public override void _PhysicsProcess(float delta)
    {
        //GD.Print(rayo.IsColliding());//si el rayo colisiona o no
        col = (Node)rayo.GetCollider();//devuelve el objeto que colisiona o vacio
        //es importante verificar que col no sea null,sino tenemos ese error
        if(col != null && col.IsInGroup("StaticBody2DAzul"))//si la colisión esta en el grupo
        {
            GD.Print("Colisiono con SPRITE AZUL");
        }
        else if(col != null && col.IsInGroup("StaticBody2DRED"))//si la colisión esta en el grupo
        {
            GD.Print("Colisiono con SPRITE ROJO");
        }
        else
        {
             GD.Print("El raycast no colisiona con nada");
        }
    }


    //exlude parent es importante para evitar que el rayo colisione con
    //un personaje que posee este mismo rayo osea evita tocar
    //al nodo padre me imagino que siempre y cuando sea
    //un cuerpo kinematico,statico o un area
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
