import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss'
})
export class EventosComponent {

  public eventos: any;

  constructor(
    private http: HttpClient,
  ){}

  ngOnInit(){
    this.getEventos();
  }

  public getEventos(): void{
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => this.eventos = response,
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
