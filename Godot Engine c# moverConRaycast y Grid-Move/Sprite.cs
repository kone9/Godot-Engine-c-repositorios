using Godot;
using System;

public class Sprite : Godot.Sprite
{
    [Export]
    private int DimensionSprite = 64;//para multiplicar por el tamaño del sprite

    private bool canMove = true;//si puede o no puede moverse

    private Timer _TimerMover;//para referenciar al timer
    private RayCast2D _RayCast2D;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _TimerMover = (Timer)GetTree().GetNodesInGroup("TimerMover")[0];//uso el grupo para buscar el nodo timer
        _RayCast2D = (RayCast2D)GetTree().GetNodesInGroup("RayCast2D")[0];//uso el grupo para buscar el nodo raycast

    }

    public override void _Input(InputEvent @event)//función para procesar entradas de teclado
    {
        int horizontal = Convert.ToInt16(Input.GetActionStrength("d") - Input.GetActionStrength("a"));//si se mueve izquierda derecha
        int vertical = Convert.ToInt16(Input.GetActionStrength("s") - Input.GetActionStrength("w"));//si se mueve abajo arriba

        if(horizontal != 0)//esto es para que no se mueva en diagonal
        {
            vertical = 0;
        }
        if(horizontal !=0 || vertical !=0)//nos podemos mover
        {
            if(canMove)//si podes mover esto lo maneja el timer
            {
                intentarMover(horizontal,vertical);
            }
        }
    }

    private void intentarMover(int x,int y)//esta función intenta mover dependiendo lo que regrese el raycast 
    {
        Vector2 newPosition = new Vector2(x,y);//toma la nueva posición
        bool isColling = MoverRaycast(x,y);//para saber si colisiona
        if(!isColling)
        {
            MoverSprite(x,y);//desde esta función muevo el sprite
        }
    }


    private bool MoverRaycast(int x, int y)//esta función es para mover el raycast
    {
        _RayCast2D.CastTo = new Vector2(x,y) * DimensionSprite;//esto rota el sprite aqui hago una multiplicación en un vector para siempre tener el tamaño del sprite

        //Esto es muy importante en el raycast,sino puede que no funcione
        _RayCast2D.ForceRaycastUpdate();//sino usamos esto puede que el raycast no detecte la colisión inmediatamente
        return _RayCast2D.IsColliding();//retorna si el raycast esta colisionado importantesimo la función de arriba
    }


    private void MoverSprite(int x,int y)//función para mover el sprite
    {
        Vector2 start = Position;//posición inicial
        Vector2 end = start + (new Vector2(x,y) * DimensionSprite);
        Position = end;//la posición final luego de llamar a esta función
        canMove = false;//no puedo moverme
        _TimerMover.Start();//inicio el timer de espera para volver a moverme
    }

    public void _on_TimerMover_timeout()//procesar la señal del timer
    {
        canMove = true;//puedo volver a moverme
    }



}
