﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfetasWebAPI.Domains;

namespace OfetasWebAPI.Utils
{
    public class Desconto
    {
        public static double Descontar(Produto _produto)
        {
            var idCatProduto = _produto.IdCategoria;

            //ALIMENTOS
            if (idCatProduto == 1)
            {
                var DiasParaVenc = _produto.DataValidade.Day - DateTime.Now.Date.Day;

                if (DiasParaVenc < 20)
                {
                    var diasPassados = 20 - DiasParaVenc ;
                    var preco = _produto.Preco;
                    double desconto = ((preco / 100) * 2)* diasPassados;

                    var novoPreco = preco - desconto;

                    return novoPreco;
                }
                 
            }

            // ELETRODOMESTICOS
            if (idCatProduto == 6)
            {
                var MesesDeUso = _produto.DataValidade.Month - DateTime.Now.Date.Month;

                if (MesesDeUso >= 2 )
                {
                    //var MesesPassados = 12 - MesesDeUso;
                    var preco = _produto.Preco;
                    double desconto = ((preco / 100) * 5) * MesesDeUso;

                    var novoPreco = preco - desconto;

                    return novoPreco;
                }

            }
            //ROUPAS
            if (idCatProduto == 2 || idCatProduto == 4)
            {
                var MesesDeUso = _produto.DataValidade.Month - DateTime.Now.Date.Month;

                if (MesesDeUso >= 2)
                {
                    //var MesesPassados = 12 - MesesDeUso;
                    var preco = _produto.Preco;
                    double desconto = ((preco / 100) * 7) * MesesDeUso;

                    var novoPreco = preco - desconto;

                    return novoPreco;
                }

            }

            //COSMETICOS
            if (idCatProduto == 3)
            {
                var MesesParaVencer = _produto.DataValidade.Month - DateTime.Now.Date.Month;

                if (MesesParaVencer < 12 )
                {
                    var MesesPassados = 12 - MesesParaVencer;
                    var preco = _produto.Preco;
                    double desconto = ((preco / 100) * 5) * MesesParaVencer;

                    var novoPreco = preco - desconto;

                    return novoPreco;
                }

            }
            return 0;

        }
    }
}
