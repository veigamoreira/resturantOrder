import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { library } from '@fortawesome/fontawesome-svg-core';
import { fas } from '@fortawesome/free-solid-svg-icons';
import { ReactiveFormsModule } from '@angular/forms';
import { PaginationModule } from 'ngx-bootstrap';
import { UsuarioService } from '../../../services/pages/usuario.service';
import { usuarioConsultaComponent } from './usuario-consulta.component';
import { usuarioConsultaRoutingModule } from './usuario-consulta-routing.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

library.add(fas);

@NgModule({
  declarations: [
    usuarioConsultaComponent
  ],
  imports: [
    CommonModule,
    usuarioConsultaRoutingModule,
    FontAwesomeModule,
    ReactiveFormsModule,
    PaginationModule.forRoot()
  ],
  providers: [
    UsuarioService
  ],
  exports: [
    usuarioConsultaComponent
  ]
})
export class UsuarioConsultaModule { }
