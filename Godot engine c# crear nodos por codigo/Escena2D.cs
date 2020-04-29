using Godot;
using System;

public class Escena2D : Node2D
{
    
    private RigidBody2D cuerpoRigido = new RigidBody2D();//asi se crean los nodos
    private Sprite Sprite = new Sprite();//asi se crean los nodos
    private Label Laber = new Label();//asi se crean los nodos
    private StaticBody2D cuerpoEstatico = new StaticBody2D();//asi se crean los nodos
    private AudioStreamPlayer audio = new AudioStreamPlayer();//asi se crean los nodos

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //siempre que creamos un nodo lo agregamos como hijo sino nose ve 
        //en la gerarquia de nodos.
        AddChild(cuerpoRigido);//se instancia 1 sola ves
        AddChild(Sprite);
        AddChild(Laber);
        AddChild(cuerpoEstatico);
        AddChild(audio);

    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
