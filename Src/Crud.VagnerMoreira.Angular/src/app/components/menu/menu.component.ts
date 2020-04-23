import { Component, OnInit } from '@angular/core';
import { CompartilhadoService } from 'src/app/services/compartilhado/compartilhado.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})

export class MenuComponent implements OnInit {
  constructor(
    public compartilhadoService: CompartilhadoService
  ) { }
  ngOnInit() { }
}
