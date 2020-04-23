import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { UsuarioService } from '../../../services/pages/usuario.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { usuarioListarResponseModel, usuarioDeletarResponseModel } from 'src/app/models/usuario.model';

@Component({
  selector: 'app-usuario-consulta',
  templateUrl: './usuario-consulta.component.html',
  styleUrls: ['./usuario-consulta.component.scss']
})

export class usuarioConsultaComponent implements OnInit {

  public usuarios: usuarioListarResponseModel[];

  constructor(
    private usuarioService: UsuarioService,
    private router: Router,
    private ts: ToastrService
  ) { }

  ngOnInit() {
    this.listar();
  }

  public listar(): void {
    this.usuarioService.listar()
      .subscribe((response: usuarioListarResponseModel[]) => {
        this.usuarios = response;
      });
  }

  public deletar(id: number) {
    this.usuarioService.deletar(id)
      .subscribe((response: usuarioDeletarResponseModel) => {
        this.listar();
      });
  }

  public editar(id: number) {
    this.router.navigate(['/usuario-cadastro/' + id]);
  }
}
