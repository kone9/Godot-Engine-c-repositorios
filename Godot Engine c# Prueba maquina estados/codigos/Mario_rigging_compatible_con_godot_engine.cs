using Godot;
using System;

public class Mario_rigging_compatible_con_godot_engine : Spatial
{
    
    private AnimationNodeStateMachinePlayback activarAnimacion;//para el nodo animationthree que contiene las animaciones
    // private string b = "text";

    private enum EstadoPersonaje//para saber en que estado esta el personaje
    {
        IDLE,
        WALK,
        RUN,
        JUMP
    }
    
    EstadoPersonaje verificarEstadoActual;//variable para verificar el estado donde estoy y asi poder crear comportamientos..Es del mismo tipo que la enumeración o algo asi,creo que se entiende
    // Called when the node enters the scene tree for the first time.

    public override void _Ready()
    {
        activarAnimacion = (AnimationNodeStateMachinePlayback)GetNode<AnimationTree>("AnimationTree").Get("parameters/playback");//con esto podemos acceder a las animaciones que estan en el nodo y el animationstateMachine
        activarAnimacion.Start("estatico_largo");//animacion inicial
    }

    //esta función precesa los estados y nos devuelve el estado actual
    //con esto podemos verificar como se encuentra el personaje
    //y ejecutar acciones
    private EstadoPersonaje CambiarEstado(EstadoPersonaje estado)//funcion para procesar los estados recibe como parametro el estado donde queremos estar
    {
        switch (estado)
        {
            case EstadoPersonaje.IDLE://si el estado recibido es igual a idle
                activarAnimacion.Travel("estatico_largo");
                return estado;//devuelvo el estado donde estoy
            case EstadoPersonaje.WALK://si el estado recibido es igual a walk
                activarAnimacion.Travel("caminar");
                return estado;
            case EstadoPersonaje.RUN://si el estado recibido es igual a run
                activarAnimacion.Travel("correr");
                return estado;
            case EstadoPersonaje.JUMP://si el estado recibido es igual a jump
                activarAnimacion.Travel("saltar_alto");
                return estado;
            default:
                return estado;//hay que usar el default si usamos un retorno en la funci+on
        }
    }




    public override void _UnhandledInput(InputEvent @event)//esta función detecta teclas precionadas,pueden hacerlo en cualquier lado pero en este ejemplo uso el INPUTEVENT
    {
        //las teclas son solo para verificar que los estados funcionan esto pueden hacerlo donde quieran y con las teclas que quieran
        if(Input.IsActionJustPressed("w"))//si presiono w
        {
            verificarEstadoActual = CambiarEstado(EstadoPersonaje.IDLE);//agrego el estado y lo guardo en la variable para verificarlo
        }
         if(Input.IsActionJustPressed("s"))//si presiono w
        {
            verificarEstadoActual = CambiarEstado(EstadoPersonaje.WALK);//agrego el estado y lo guardo en la variable para verificarlo
        }
         if(Input.IsActionJustPressed("a"))//si presiono w
        {
            verificarEstadoActual = CambiarEstado(EstadoPersonaje.RUN);//agrego el estado y lo guardo en la variable para verificarlo
        }
         if(Input.IsActionJustPressed("d"))//si presiono w
        {
            verificarEstadoActual = CambiarEstado(EstadoPersonaje.JUMP);//agrego el estado y lo guardo en la variable para verificarlo
        }
    }

    public override void _Process(float delta)
    {
        GD.Print("el estado actual es: " + verificarEstadoActual);//para saber en que estado estoy
    }
}
