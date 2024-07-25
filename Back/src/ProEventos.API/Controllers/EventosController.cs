using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ProEventos.API.Models;
using ProEventos.API.data;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {

        // public IEnumerable<Evento> _evento  = new Evento[]{
        //     new Evento(){
        //         EventoId = 1,
        //         Tema = "Angular 11 e .NET 5",
        //         Local = "Belo Horizonte",
        //         Lote = "1º Lote",
        //         QtdPessoas = 250,
        //         DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
        //         ImagemURL = "foto1.png",
        //     },
        //     new Evento(){
        //         EventoId = 2,
        //         Tema = "Angular e suas novidades",
        //         Local = "São Paulo",
        //         Lote = "2º Lote",
        //         QtdPessoas = 350,
        //         DataEvento = DateTime.Now.AddDays(3).ToString(),
        //         ImagemURL = "foto2.png",
        //     },
        // };


        private readonly DataContext _context;

        public EventosController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo de Post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete com id = {id}";
        }
    }
}

/*
detalhando request Http
    verbos, headers e content
    ações a serem executadas no servidor 

    verbos
        Get: requisitar recursos (request resource)
        Post: criar recursos(create resource) 
        Put: atualizar recursos(update resource)
        Patch: atualizar recursos parcial(update partial)
        Delete: deletar recursos(delete resource)

        - existem outros, mas podemos dizer que esses são os principais

    headers 
        metadados sobre a requisição (request)
            content type: formato do conteudo
            content length: tamanho do conteudo
            authorization: quem fez a chamada
            accept: quais tipos são aceitaveis 
            cookies: passagem de dados pela requisição

        - existem muitos outros recursos no headers

    content
        conteudo referente à requisição(content request)
            html, css, js, xml, json...
            conteudo não é validado com qualquer verbo
            informações para ajudar a atender a requisição
            onde passar tipos binarios e blobs comuns 


detalhando request Http
    status code, headers, content 

    status code
        situação da operação (100-599)
            100-199: informação(informational)
            200-299: sucesso(success)
            300-399: redirecionamento(redirection)
            400-499: erro do cliente(client errors)
            500-599: erro do servidor(internal server errors)

    headers
        metadados da resposta (response)
            content type: formato do conteudo
            content length: tamanho do conteudo
            expires: quando considerar obsoleto
            accept: quais tipos são aceitaveis 
            cookies: passagem de dados pela resposta
        - existem muitos outros recursos no headers

    content 
        conteudo (content response)
            html, css, js, xml, json...
            onde passar tipos binarios e blobs comuns 
            apis frequentemente tem seus proprios tipos
                json provavelmente é o mais comum

----------
exemplo
    request
        verbo: Post
        header: Content Length: 15
        content: Olá mundo cruel.

    response
        status code: 201
        header: Content Type: Text
        content: Olá! Sim, eu sou muito cruel.
----------


*/
