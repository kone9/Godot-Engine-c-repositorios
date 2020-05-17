using Godot;
using System;

public class Node2D : Godot.Node2D
{
    
    Sprite _sprite;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _sprite = GetNode<Sprite>("Sprite");//busco el nodo,ojo sino existe en la escena el programa se termina porque no encuentra el nodo al comienzo
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        //GD.Print(_sprite);//imprimo por consola el valor que posee la variable sprite
        //aunque borre el nodo seguia estando en la variable,para saber
        //si un nodo no esta en la gerarquia de nodos podes usar la
        //siguiente función de "Node"
        GD.Print(_sprite.IsInsideTree());//devuelve verdadero o falso si esta o no esta en el arbol de nodos
        if(Input.IsActionJustPressed("w"))
        {
            _sprite.QueueFree();
        }
         if(Input.IsActionJustPressed("s"))
        {
            AddChild(_sprite);
        }

    }
}
