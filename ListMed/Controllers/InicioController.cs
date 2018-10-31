﻿using ListMed.DTO;
using ListMed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace ListMed.Controllers
{
    public class InicioController : Controller
    {
        private MedListContext db = new MedListContext();
        HttpClient client = new HttpClient();

        public InicioController()
        {
            //client.BaseAddress = new Uri("https://maps.googleapis.com");
            
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Inicio
        public ActionResult Index()
        {
            //db.Especialidades.Add(new Especialidade() { descricao = "Acupuntura" });
            //db.Especialidades.Add(new Especialidade() { descricao = "Angiologia" });
            //db.Especialidades.Add(new Especialidade() { descricao = "Cardiologia" });
            //db.Especialidades.Add(new Especialidade() { descricao = "Clínica Médica" });
            //db.Especialidades.Add(new Especialidade() { descricao = "Dermatologia" });
            //db.Especialidades.Add(new Especialidade() { descricao = "Endocrinologia" });
            //db.Especialidades.Add(new Especialidade() { descricao = "Gastroenterologia" });
            //db.Especialidades.Add(new Especialidade() { descricao = "Ginecologia" });
            //db.Especialidades.Add(new Especialidade() { descricao = "Mastologia" });
            //db.Especialidades.Add(new Especialidade() { descricao = "Neurologia" });
            //db.Especialidades.Add(new Especialidade() { descricao = "Nutrição" });
            //db.Especialidades.Add(new Especialidade() { descricao = "Ortopedia" });
            //db.Especialidades.Add(new Especialidade() { descricao = "Otorrinolaringologia" });
            //db.Especialidades.Add(new Especialidade() { descricao = "Pediatria" });
            //db.Especialidades.Add(new Especialidade() { descricao = "Psiquiatria" });
            //db.Especialidades.Add(new Especialidade() { descricao = "Urologia" });
            //db.SaveChanges();
            return View();
        }

        [HttpPost]
        public JsonResult ListarLocalidades(string nome)
        {
            var localidades = db.Localidades.Where(l => (l.Tipo == "C" || l.Tipo == "E")  && l.Descricao.ToUpper().Contains(nome.ToUpper())).Select(a => new
            {
                label = a.Descricao,
                value = a.Descricao
            }).Take(10).ToList();
            return Json(localidades);
        }

        [HttpPost]
        public JsonResult AddEstado(List<estados> estados)
        {
            foreach(var estado in estados)
            {
                db.Localidades.Add(new Localidade { Descricao = estado.desc, UF = estado.uf, Tipo = "E" });
            }
            db.SaveChanges();
            return Json("OK");
        }
    }
}