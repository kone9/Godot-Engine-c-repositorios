using Godot;
using System;

public class Camara : Godot.Camera
{

    Camera segundaCamara;

    public override void _Ready()
    {
        Input.SetMouseMode(Input.MouseMode.Captured);//esto es para capturar el mouse
        segundaCamara = GetNode<Camera>("ViewportContainer/Viewport/Camera");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

    }

    public override void _Input(InputEvent @event)//función para procesar entradas como por ejemplo el mouse
    {
        if(@event is InputEventMouseMotion movimientoMouse)//si el mouse se esta moviendo
        {
            RotateY(Mathf.Deg2Rad(-movimientoMouse.Relative.x));//roto el objeto si muevo el mouse en el eje X
            //segundaCamara.RotateY(Mathf.Deg2Rad(movimientoMouse.Relative.x));//roto el objeto si muevo el mouse en el eje X

        }
    }

}
