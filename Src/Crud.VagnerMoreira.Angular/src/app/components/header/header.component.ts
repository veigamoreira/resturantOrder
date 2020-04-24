import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CompartilhadoService } from 'src/app/services/compartilhado/compartilhado.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public nome: string;

  constructor(
    public compartilhadoService: CompartilhadoService,
    private router: Router
  ) {  }

  ngOnInit() {
     this.nome = 'Vagner Moreira';
  }
}
