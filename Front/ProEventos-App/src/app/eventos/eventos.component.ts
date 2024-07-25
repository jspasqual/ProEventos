import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss'
})
export class EventosComponent {

  public eventos: any = [];
  public eventosFiltrados: any = [];

  larguraImagem: number = 150;
  margemImagem: number = 5;
  mostrarImagem: boolean = true;
  private _filtroLista: string = '';

  public get filtroLista(): string{
    return this._filtroLista;
  }
  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this._filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos; //verifica se o 'campo de busca' tem valor, se tiver chama metodo que faz o filtro passando o valor do campo de busca, se não retorna lista de eventos inalterada(completa/original)
  }
  filtrarEventos(filtrarPor: string): any{ //recebe o conteudo do compo de busca como parametro
    filtrarPor = filtrarPor.toLowerCase(); //transforma termo de busca em minusculas
    return this.eventos.filter( //filtro da 'lista de eventos'
      (evento: { tema: string; local: string; }) => evento.tema.toLowerCase().indexOf(filtrarPor) !== -1 || // a cada evento da 'lista de eventos', transforma conteudo do campo tema em minusculas, e realiza o filtro pelo termo e busca, se resultado for diferente de -1 então significa que encontrou o termo buscado
                                                    evento.local.toLowerCase().indexOf(filtrarPor) !== -1 //agora a busca tbm eh feita no campo local
    )
  }

  constructor(
    private http: HttpClient,
  ){}

  ngOnInit(){
    this.getEventos();
  }

  alterarImagem(){
    this.mostrarImagem = !this.mostrarImagem;
  }

  public getEventos(): void{
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos;
      },
      error => console.log(error),
    )
    /*
    this.eventos = [
      {
        tema: 'Angular 11',
        local: 'Belo Horizonte',
      },
      {
        tema: '.NET 5',
        local: 'São Paulo',
      },
      {
        tema: 'Novidades do Angular',
        local: 'Rio de Janeiro',
      },
    ];
    */
  }


}
