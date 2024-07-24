using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using ProEventos.API.Models;

namespace ProEventos.API.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){}
        public DbSet<Evento> Eventos {get; set;}
    }
}

/*
contexto que vamos utilizar para fazer a criação da tabela de evento lá no sqlite
para que isso aconteça preciso herdar do 
    DbContext 
        que vel lá do 
            using Microsoft.EntityFrameworkCore // deveria estar fincionando com ctrl_. mas não está, provavelmente problema com a extensão em uma versão muito antiga

*/