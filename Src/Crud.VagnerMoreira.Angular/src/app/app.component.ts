import { Component } from '@angular/core';
import { CompartilhadoService } from './services/compartilhado/compartilhado.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  titulo = 'Crud';
  exibirTemplate = true;

  constructor(public compartilhadoService: CompartilhadoService) { }
}
