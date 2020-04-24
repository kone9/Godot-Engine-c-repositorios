using Godot;
using System;

public class KinematicBody2D : Godot.KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export]
    public int velocidad = -100;
    private Vector2 movimiento = new Vector2(0,1);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public override void _PhysicsProcess(float delta)
    {
        //no es necesario multiplicar el delta en el move_and_slide o move_and_collide
        MoveAndSlide(movimiento * velocidad);//multiplicación de vectores,osea se multiplica velocidad por "X" y "Y"
    
        //esto es para que no se salga de la pantalla
        if(Position.y < 0)
        {
            Position = new Vector2(500,500);
        }
    }
    public void _on_TimerAumentarVelocidad_timeout()//aqui creo la señal en GDscript se hace automatico,osea cuando el timer llego a cero
    {
        velocidad -= 100;//el movimiento es negativo por eso disminuyo 100 cada ves que termina el timer
        GD.Print("la velocidad de moviento actual es = " ,velocidad);
    }
}
    
