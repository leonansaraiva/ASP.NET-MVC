﻿using Inicial.DAO;
using Inicial.Filtros;
using Inicial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inicial.Controllers
{
    [AutorizacaoFilter]
    public class ProdutoController : Controller
    {
        // GET: Produto
        [Route("produtos", Name = "ListaProdutos")]
        public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();
            return View(produtos);
        }

        public ActionResult Form()
        {
            var dao = new CategoriasDAO();
            ViewBag.Categorias = dao.Lista();
            ViewBag.Produto = new Produto();

            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            int idDaInformatica = 1;
            if (produto.CategoriaId.Equals(idDaInformatica) && produto.Preco < 100)
            {
                ModelState.AddModelError("produto.InformaticaComPrecoInvalido", "Produtos da categoria informática devem ter preço maior do que 100");
            }

            if (ModelState.IsValid)
            {
                ProdutosDAO dao = new ProdutosDAO();
                dao.Adiciona(produto);
                return RedirectToAction("Index", "Produto");
            }else
            {
                CategoriasDAO categoriasDao = new CategoriasDAO();
                ViewBag.Categorias = categoriasDao.Lista();
                ViewBag.Produto = produto;

                return View("Form");
            }
        }

        [Route("produtos/{id}", Name = "VisualizaProduto")]
        public ActionResult Visualiza(int id)
        {
            var dao = new ProdutosDAO();
            ViewBag.Produto = dao.BuscaPorId(id);
            return View();
        }

        public ActionResult DecrementaQtd(int id)
        {
            var dao = new ProdutosDAO();
            var produto = dao.BuscaPorId(id);
            produto.Quantidade--;
            dao.Atualiza(produto);

            return Json(produto);
        }

    }
}