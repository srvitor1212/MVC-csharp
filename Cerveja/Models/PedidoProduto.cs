﻿namespace Cerveja.Models
{
    public class PedidoProduto
    {
        public int Id { get; set; }
        
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }


        public Rotulo Rotulo { get; set; }
        public int RotuloId { get; set; }

        public PedidoProduto()
        {
        }
        public PedidoProduto(int id, Pedido pedido, Rotulo rotulo)
        {
            this.Id = id;
            this.Pedido = pedido;
            this.Rotulo = rotulo;
        }
    }
}