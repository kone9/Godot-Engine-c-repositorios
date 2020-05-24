using Godot;
using System;

public class Area2DMoverMouse : Area2D
{
    
    bool puedoMover = false;//para saber si puedo mover

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(puedoMover)//si puedo mover
        {
            Position = GetGlobalMousePosition();//la posición de este nodo sera la misma que la del mouse
        }
    }
    private void _on_Area2DMoverMouse_input_event(Node viewport,InputEvent evento,int shapeIdx)
    {
        if(evento.IsActionPressed("click_izquierdo"))//si estoy presionando click izquierdo
        {
            GD.Print("estoy presionando click");
            puedoMover = true;//puedo moverme
        }
        if(evento.IsActionReleased("click_izquierdo"))//si solte el click izquierdo
        {
            GD.Print("estoy soltando click");
            puedoMover = false;//no puedo moverme
        }
    }


    
}
